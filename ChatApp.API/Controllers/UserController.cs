using ChatApp.Core.Interfaces;
using ChatApp.Core.Interfaces.Services;
using ChatApp.Dtos.UserDto;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService service) : ControllerBase
{
    [HttpPost("AddUser")]
    public OkObjectResult AddUser([FromBody] AddUserRequestDto dto)
    {
        var id = service.AddUser(dto.Username);
        return Ok(id);
    }
}