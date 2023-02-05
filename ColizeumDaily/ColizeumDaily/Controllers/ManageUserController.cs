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
    public UserModel UserGet(string Username)
    {
        return _manageUserService.UserGet(Username);
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
    
    [HttpGet] 
    [Route("home/streakDelete")] 
    public void StreakDelete() 
    { 
        _manageUserService.StreakDelete(); 
    } 
}