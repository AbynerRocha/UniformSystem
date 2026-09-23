using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace UniformSystem.Security;

public class PasswordHasher
{
    private const int MemorySizeKb = 19456;
    private const int Iterations = 2;
    private const int DegreeOfParallelism = 2;
    private const int SaltLength = 16;
    private const int HashLength = 32;

    public string Hash(string password)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(password);

        var salt = RandomNumberGenerator.GetBytes(SaltLength);
        var hash = DeriveHash(password, salt);

        return string.Join("$",
            "v1",
            "argon2id",
            MemorySizeKb,
            Iterations,
            DegreeOfParallelism,
            Convert.ToBase64String(salt),
            Convert.ToBase64String(hash)
        );
    }

    public bool Verify(string password, string hash)
    {
        if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(hash))
            return false;

        var parts = hash.Split('$');

        if (parts.Length != 7 ||
            parts[0] != "v1" ||
            parts[1] != "argon2id" ||
            !int.TryParse(parts[2], out var memorySizeKb) ||
            !int.TryParse(parts[3], out var iterations) ||
            !int.TryParse(parts[4], out var degreeOfParallelism))
            return false;

        try
        {
            var salt = Convert.FromBase64String(parts[5]);
            var expectedHash = Convert.FromBase64String(parts[6]);
            
            var actualHash = DeriveHash(password, salt, memorySizeKb, iterations, degreeOfParallelism);
           
            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }
        catch (FormatException)
        {
            return false;
        }
    }

    private static byte[] DeriveHash(string password, byte[] salt, 
        int memorySizeKb = MemorySizeKb,
        int iterations = Iterations,
        int degreeOfParallelism = DegreeOfParallelism,
        int hashLength = HashLength
    )
    {
        using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            MemorySize = memorySizeKb,
            Iterations = iterations,
            DegreeOfParallelism = degreeOfParallelism
        };

        return argon2.GetBytes(hashLength);
    }
}
