namespace Backend.Models;

public class Password
{
    public string OriginalPassword { get; set; }
    
    public string EncryptedPassword { get; set; }
    
    public ulong Complexity { get; set; }
}