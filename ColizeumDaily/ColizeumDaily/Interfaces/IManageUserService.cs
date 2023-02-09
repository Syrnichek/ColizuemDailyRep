<<<<<<< master:ColizeumDaily/ColizeumDaily/Models/IManageUserService.cs
namespace ColizeumDaily.Models;

public interface IManageUserService
{
    public UserModel UserGet(string Username);

    public void UserVisitCheck(string Username);

    public void UserReg(string Username, string TelegramUsername);
    
    public void StreakDelete(); 
=======
using ColizeumDaily.Models;

namespace ColizeumDaily.Interfaces;

public interface IManageUserService
{
    public UserModel UserGet(string Username);

    public void UserVisitCheck(string Username);

    public void UserReg(string Username, string TelegramUsername);
    
>>>>>>> Доделать бэкграунд таску в этой ветке:ColizeumDaily/ColizeumDaily/Interfaces/IManageUserService.cs
}