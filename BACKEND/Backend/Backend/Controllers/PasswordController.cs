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
    public ActionResult<Password> Encrypt([FromBody] BodyContent bodyContent)
    {
        try
        {
            return Ok(_passwordEncryptingService.Encrypt(bodyContent.OriginalPassword,bodyContent.Offset));
        }
        catch (Exception )
        {
            return BadRequest();
        }
        
    }
}