namespace Backend.Models;

public class Password
{
    public string OriginalPassword { get; set; }
    
    public string EncryptedPassword { get; set; }
    
    public int Complexity { get; set; }
}