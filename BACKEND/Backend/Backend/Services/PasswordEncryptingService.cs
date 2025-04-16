using Backend.Models;

namespace Backend.Services;

public class PasswordEncryptingService:IPasswordEncryptingService
{
    public Password Encrypt(string password,int offset)
    {
        return new Password()
        {
            OriginalPassword = password,
                Complexity = 0,
                EncryptedPassword = CreateEncrypt(password, offset)
            
        };
    }


    private string CreateEncrypt(string password, int offset)
    {
        
        return password;
    }
}


