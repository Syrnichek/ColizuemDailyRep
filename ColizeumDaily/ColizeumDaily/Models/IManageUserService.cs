namespace ColizeumDaily.Models;

public interface IManageUserService
{
    public void UserGet(string Username);

    public void UserVisitCheck(string Username);

    public void UserReg(string Username, string TelegramUsername);
    
}