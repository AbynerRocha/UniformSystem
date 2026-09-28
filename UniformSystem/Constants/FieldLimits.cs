namespace UniformSystem.Constants;

public static class FieldLimits
{
    public static class Email
    {
        public const int MinLength = 5;
        public const int MaxLength = 255;
    }

    public static class User
    {
        public const int NameMaxLength = 255;
        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 72;
    }

    public static class Employee
    {
        public const int NameMaxLength = 255;
    }

    public static class Uniform
    {
        public const int NameMaxLength = 255;
        public const int CategoryNameMaxLength = 255;
        public const int ReferenceMaxLength = 100;
        public const int ReferenceMinLength = 3;
        public const int SizeMaxLength = 4;
        public const int SexMaxLength = 1;
    }
}