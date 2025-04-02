namespace Backend.Application.Common.Interfaces.Authentication;

public interface ISecurePasswordProvider
{
    string Encrypt(string password, string email);
    bool Verify(string password, string hashedPassword, string email);
}