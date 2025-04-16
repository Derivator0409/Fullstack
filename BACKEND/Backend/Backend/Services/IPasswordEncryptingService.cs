using Backend.Models;

namespace Backend.Services;

public interface IPasswordEncryptingService
{
    Password Encrypt(string password,int offset);
}