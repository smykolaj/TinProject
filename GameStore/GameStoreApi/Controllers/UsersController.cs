using System.Security.Claims;
using GameStore.DTOs;
using GameStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers;

[Controller]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            var list = new List<GetUserPartialDTO>();
            list = await _service.GetAllUsers();
            return Ok(list);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    
    [Authorize]
    [HttpGet("{idUser:int}")]
    public async Task<IActionResult> GetFullUserInfo(int idUser)
    {
        if (!await _service.ExistsById(idUser))
        {
            return NotFound();
        }
        
        if (!User.IsInRole("Admin") && !User.IsInRole("Manager") &&
            !User.HasClaim(ClaimTypes.Name, await _service.GetEmailById(idUser)))
            return Unauthorized();
        try
        {
            var user = new GetUserFullDTO();
            user = await _service.GetFullUserInfo(idUser);
            return Ok(user);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

}