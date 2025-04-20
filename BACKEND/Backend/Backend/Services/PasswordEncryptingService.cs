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
        bool SpecialCase = false;
        bool UpperCase = false;
        
        string newpass="";
        for (int i = 0; i < password.Length; i++)
        {
            if (31 < password[i] && 64 > password[i])
            {
               SpecialCase = true;
               i=password.Length; 
            }

        }




        return newpass;
    }
}


