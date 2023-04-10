using ColizeumDaily.Exceptions;
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
    [Route("api/manageUser/userGet")]
    public UserModel UserGet(string UserNumber)
    {
        return _manageUserService.UserGet(UserNumber);
    }

    [HttpGet]
    [Route("api/manageUser/userStockGet")]
    public string UserStockGet(string UserNumber)
    {
        return _manageUserService.UserStockGet(UserNumber);
    }
    
    [HttpGet]
    [Route("api/manageUser/userVisitCheck")]
    public IActionResult UserVisitCheck(string UserNumber)
    {
        try
        {
            _manageUserService.UserVisitCheck(UserNumber);
            return Ok();
        }

        catch (MaximumStockException ex)
        {
            return StatusCode(247, "Пользователь достиг максимальной награды");
        }
        
        catch (UserAlreadyCheckException ex)
        {
            return StatusCode(246, "Сегодня пользователь уже отмечался");
        }
    }

    [HttpGet]
    [Route("api/manageUser/nightPacksCheck")]
    public IActionResult NightPacksCheck(string UserNumber)
    {
        try
        {
            _manageUserService.NightPacksCheck(UserNumber);
            return Ok();
        }
        catch (UserAlreadyCheckException ex)
        {
            return StatusCode(248, "Сегодня пользователь уже отмечался");
        }
        catch (MaximumNightPacksException ex)
        {
            return StatusCode(249, "Пользователь получил бонусный ночной пакет");
        }
    }

    [HttpGet]
    [Route("api/manageUser/userReg")]
    public IActionResult UserReg(string UserNumber, string TelegramUsername)
    {
        try
        {
            _manageUserService.UserReg(UserNumber, TelegramUsername);
            return Ok();
        }
        catch (UserAlreadyExistsException ex)
        {
            return StatusCode(420, "Пользователь уже существует");
        }
    }
}