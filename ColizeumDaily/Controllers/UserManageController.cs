using ColizeumDaily.Interfaces;
using ColizeumDaily.Models;
using Microsoft.AspNetCore.Mvc;

namespace ColizeumDaily.Controllers;

[Route("api/userManage")]
public class UserManageController : Controller
{
    private readonly IUserManageService _userManageService;

    public UserManageController(IUserManageService userManageService)
    {
        _userManageService = userManageService;
    }
    
    [HttpGet]
    [Route("userGet")]
    public UserModel UserGet(string UserNumber)
    {
        return _userManageService.UserGet(UserNumber);
    }

    [HttpGet]
    [Route("userStockGet")]
    public string UserStockGet(string UserNumber)
    {
        return _userManageService.UserStockGet(UserNumber);
    }
}