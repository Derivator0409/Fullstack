using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;


[ApiController]
[Route("[controller]")]
public class PasswordController(IPasswordEncryptingService service):ControllerBase
{
    private readonly IPasswordEncryptingService _passwordEncryptingService=service;
    [HttpPost]
    public ActionResult<Password> Encrypt([FromBody] string password)
    {
        try
        {
            return Ok(_passwordEncryptingService.Encrypt(password));
        }
        catch (Exception )
        {
            return BadRequest();
        }
        
    }
}