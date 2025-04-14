using Backend.Models;

namespace Backend.Services;

public class PasswordEncryptingService:IPasswordEncryptingService
{
    public Password Encrypt(string password)
    {
        return new Password()
        {

        };
    }
}