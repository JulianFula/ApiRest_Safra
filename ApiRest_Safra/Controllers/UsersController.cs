﻿using ApiRest_Safra.Models.DTO;
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

    [Authorize]
    [HttpPut]
    [Route("UpdateUser")]
    public async Task<IActionResult> UpdateUser(UserDTO UserRequest)
    {
        var result = await _UserServices.UpdateUser(UserRequest);
        if (result == null)
        {
            return Unauthorized();
        }
        return Ok(result);
    }

    [Authorize]
    [HttpDelete]
    [Route("DeleteUser")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var result = await _UserServices.DeleteUser(id);
        if (result == null)
        {
            return Unauthorized();
        }
        return Ok(result);
    }
}
