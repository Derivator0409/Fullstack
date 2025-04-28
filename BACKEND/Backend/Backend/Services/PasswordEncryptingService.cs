using Backend.Models;

namespace Backend.Services;

public class PasswordEncryptingService:IPasswordEncryptingService
{
    public Password Encrypt(string password,int offset)
    {
        return new Password()
        {
            OriginalPassword = password,
                Complexity = Complexity(password),
                EncryptedPassword = CreateEncrypt(password, offset)
            
        };
    }

    private int Complexity(string password)
    {
        bool SpecialCase = false;
        bool UpperCase = false;
        
        for (int i = 0; i < password.Length; i++)
        {
            if (32 < password[i] && 65 > password[i])
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

        int complexity = 0;
        switch (SpecialCase)
        {
            case true:
            {
                complexity = (int)Math.Pow(94,password.Length);
                break;
            }
            case false:
            {
                switch (UpperCase)
                {
                    case true:
                        complexity = (int)Math.Pow(52,password.Length);
                        break;
                    
                    case false:
                        complexity = (int)Math.Pow(26,password.Length);
                        break;
                    
                }
                

                break;
            }
        }
        return complexity;   
    }
    
    

    private string CreateEncrypt(string password, int offset)
    {
        //32-től 126-ig
        bool SpecialCase = false;
        bool UpperCase = false;
        int full;
        int remainder;
        
        string newpass="";
        for (int i = 0; i < password.Length; i++)
        {
            if (32 < password[i] && 65 > password[i])
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
                if (password[i] + offset < 123)
                {
                    newpass+=(char)(password[i] + offset);
                }
                else
                {
                    newpass+=(char)(password[i] + offset-26);
                }
            }else if (SpecialCase == false && UpperCase == true)//Nagy betű megjelenése
            {
                if(offset>52 && i == 0)
                {
                    full=offset/52;
                    remainder = offset-full*52;
                    offset = remainder; 
                }

                if (password[i] + offset < 91)
                {
                    newpass+=(char)(password[i] + offset);
                }
                else
                {
                    if (password[i] + offset + 6 < 123)
                    {
                        if (password[i] > 96 && password[i] < 123)
                        {
                            newpass+=(char)(password[i] + offset);
                        }//csak kisbetűre való figyelés
                        else
                        {
                            newpass+=(char)(password[i] + offset+6);
                        }
                    }
                    else
                    {
                        if (password[i] + offset - 52 > 90 && password[i] + offset - 52 < 96)
                        {
                            newpass += (char)(password[i] + offset - 52 - 6);
                        }
                        else
                        {
                            newpass+=(char)(password[i] + offset - 52);
                        }

                    }
                }
            }
            else //speciális karakterek megjelnése
            {
                if (offset > 94 && i == 0)
                {
                    full=offset/94;
                    remainder = offset-full*94;
                    offset = remainder;
                }
                if(password[i] + offset < 127)
                {
                    newpass+=(char)(password[i] + offset);
                }
                else
                {
                    newpass+=(char)(password[i] + offset-94);
                }
            }
        }
        




        return newpass;
    }
}


