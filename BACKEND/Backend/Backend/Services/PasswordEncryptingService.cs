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
        int full;
        int remainder;
        
        string newpass="";
        for (int i = 0; i < password.Length; i++)
        {
            if (31 < password[i] && 64 > password[i])
            {
                SpecialCase = true;
                i = password.Length;
            }
            else if (64 < password[i] && 91 > password[i])
            {
                UpperCase = true;
            }
            else if (90 < password[i] && 97 > password[i])
            {
                SpecialCase = true;
                i = password.Length;
            }
            else if (122 < password[i])
            {
                SpecialCase = true;
                i = password.Length;
            }
        }

        for (int i = 0; i < password.Length; i++)
        {
            if (SpecialCase == false && UpperCase == false)//hamis hamis csak kisbetű van
            {
                //97-122
                if (offset > 26 && i == 0)
                {
                    full=offset/26;
                    remainder = offset-full*26;
                    offset = remainder;
                }
                if (password[i] + offset < 122)
                {
                    newpass+=(char)(password[i] + offset);
                }
                else
                {
                    newpass+=(char)(password[i] + offset-26);
                }
            }else if (SpecialCase == false && UpperCase == true)
            {
                if(offset>52 && i == 0)
                    {
                    full=offset/52;
                    remainder = offset-full*52;
                    offset = remainder;
                    }
            }
            else
            {
                        
            }
        }
        




        return newpass;
    }
}


