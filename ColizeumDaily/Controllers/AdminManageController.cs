using ColizeumDaily.Exceptions;
using ColizeumDaily.Interfaces;
using ColizeumDaily.Models;
using Microsoft.AspNetCore.Mvc;

namespace ColizeumDaily.Controllers;

[Route("api/adminManage")]
public class AdminManageController : Controller
{
    private readonly IAdminManageService _adminManageService;

    public AdminManageController(IAdminManageService userManageService)
    {
        _adminManageService = userManageService;
    }
    
    [HttpGet]
    [Route("userGet")]
    public UserModel UserGet(string UserNumber)
    {
        return _adminManageService.UserGet(UserNumber);
    }

    [HttpGet]
    [Route("userStockGet")]
    public string UserStockGet(string UserNumber)
    {
        return _adminManageService.UserStockGet(UserNumber);
    }
    
    [HttpGet]
    [Route("userVisitCheck")]
    public IActionResult UserVisitCheck(string UserNumber)
    {
        try
        {
            _adminManageService.UserVisitCheck(UserNumber);
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
    [Route("nightPacksCheck")]
    public IActionResult NightPacksCheck(string UserNumber)
    {
        try
        {
            _adminManageService.NightPacksCheck(UserNumber);
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
    [Route("userReg")]
    public IActionResult UserReg(string UserNumber, string TelegramUsername)
    {
        try
        {
            _adminManageService.UserReg(UserNumber, TelegramUsername);
            return Ok();
        }
        catch (UserAlreadyExistsException ex)
        {
            return StatusCode(420, "Пользователь уже существует");
        }
    }
}