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
    [Route("home/userGet")]
    public void UserGet(string Username)
    {
        _manageUserService.UserGet(Username);
    }
    
    [HttpGet]
    [Route("home/userVisitCheck")]
    public void UserVisitCheck(string Username)
    {
        _manageUserService.UserVisitCheck(Username);
    }
    
    [HttpGet]
    [Route("home/userReg")]
    public void UserReg(string Username, string TelegramUsername)
    {
        _manageUserService.UserReg(Username, TelegramUsername);
    }
}