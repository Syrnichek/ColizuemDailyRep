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
    public void UserGet()
    {
        
    }
    
    [HttpGet]
    [Route("home/userVisitCheck")]
    public void UserVisitCheck()
    {
        
    }
    
    [HttpGet]
    [Route("home/userReg")]
    public void UserReg(string Username, string TelegramUsername)
    {
        _manageUserService.UserReg(Username, TelegramUsername);
    }
}