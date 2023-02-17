using ColizeumDaily.Models;

namespace ColizeumDaily.Interfaces;

public interface IManageUserService
{
    public UserModel UserGet(int UserNumber);

    public void UserVisitCheck(int UserNumber);

    public void NightPacksCheck(int UserNumber);
    
    public void UserReg(int UserNumber, string TelegramUsername);
}