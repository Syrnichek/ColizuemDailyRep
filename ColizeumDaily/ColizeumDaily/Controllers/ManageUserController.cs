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
    public UserModel UserGet(int UserNumber)
    {
        return _manageUserService.UserGet(UserNumber);
    }
    
    [HttpGet]
    [Route("api/userVisitCheck")]
    public void UserVisitCheck(int UserNumber)
    {
        _manageUserService.UserVisitCheck(UserNumber);
    }

    [HttpGet]
    [Route("api/nightPacksCheck")]
    public void NightPacksCheck(int UserNumber)
    {
        _manageUserService.NightPacksCheck(UserNumber);
    }

        [HttpGet]
    [Route("api/userReg")]
    public void UserReg(int UserNumber, string TelegramUsername)
    {
        _manageUserService.UserReg(UserNumber, TelegramUsername);
    }
}