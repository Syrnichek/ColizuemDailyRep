using ColizeumDaily.Interfaces;
using ColizeumDaily.Models;
using Microsoft.AspNetCore.Mvc;

namespace ColizeumDaily.Controllers;

public class ManageUserController : Controller
{
    private readonly IManageUserService _manageUserService;

    public ManageUserController(IManageUserService manageUserService)
    {
        _manageUserService = manageUserService;
    }
    
    [HttpGet]
    [Route("api/userGet")]
    public UserModel UserGet(string UserNumber)
    {
        return _manageUserService.UserGet(UserNumber);
    }
    
    [HttpGet]
    [Route("api/userVisitCheck")]
    public IActionResult UserVisitCheck(string UserNumber)
    {
        try
        {
            _manageUserService.UserVisitCheck(UserNumber);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(246, "Сегодня пользователь уже отмечался");
        }
    }

    [HttpGet]
    [Route("api/nightPacksCheck")]
    public IActionResult NightPacksCheck(string UserNumber)
    {
        try
        {
            _manageUserService.NightPacksCheck(UserNumber);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(245, "Сегодня пользователь уже отмечался");
        }
    }

    [HttpGet]
    [Route("api/userReg")]
    public IActionResult UserReg(string UserNumber, string TelegramUsername)
    {
        try
        {
            _manageUserService.UserReg(UserNumber, TelegramUsername);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(420, "Пользователь уже существует");
        }
    }
}