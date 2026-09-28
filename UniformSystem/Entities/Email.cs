namespace UniformSystem.Entities;

public readonly struct Email
{
    private string Value { get; init; }

    public Email(string value)
    {
        if(string.IsNullOrWhiteSpace(value) || !ValidateEmail(value))
            throw new ArgumentException($"Invalid email address: {value}");

        this.Value = value;
    }

    public static bool ValidateEmail(string email)
    {
        var trimmedEmail = email.Trim();

        if (trimmedEmail.EndsWith('.'))
            return false;

        try
        {
            var addr = new System.Net.Mail.MailAddress(trimmedEmail);
            return addr.Address == trimmedEmail;
        }
        catch
        {
            return false;
        }
    }
    
    public static implicit operator string(Email email) => email.Value;
    public override string ToString() => Value;
}
