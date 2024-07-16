using ApiRest_Safra.Models.User;
using ApiRest_Safra.Services.Authorization;
using ApiRest_Safra.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest_Safra.Controllers;


[Route("api/")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserServices _UserServices;
    //constructor
    public UsersController(IUserServices userServices)
    {
        _UserServices = userServices;
    }

    [HttpPost]
    [Route("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] UserRequest UserRequest)
    {
        var result = await _UserServices.CreateUser(UserRequest);
        if (result == null)
        {
            return Unauthorized();
        }

        return Ok(result);

    }

    [Authorize]
    [HttpGet]
    [Route("GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _UserServices.GetAllUsers();
        if (result == null)
        {
            return Unauthorized();
        }
        return Ok(result);
    }
}
