using ColizeumDaily.Models;

namespace ColizeumDaily.Interfaces;

public interface IManageUserService
{
    public UserModel UserGet(string Username);

    public void UserVisitCheck(string Username);

    public void UserReg(string Username, string TelegramUsername);

    public void StreakDelete();
}