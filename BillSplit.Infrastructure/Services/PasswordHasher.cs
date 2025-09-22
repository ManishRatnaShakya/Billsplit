using BCrypt.Net;
using BillSplit.Application.Interfaces.Authentication;

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password cannot be empty or null");

        // Work factor of 11 is recommended for balance between security and performance
        return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 11);
    }

    public bool VerifyPassword(string plainPassword, string hashedPassword)
    {
        if (string.IsNullOrWhiteSpace(hashedPassword))
            throw new ArgumentException("Hashed password cannot be null or empty");

        return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
    }
}