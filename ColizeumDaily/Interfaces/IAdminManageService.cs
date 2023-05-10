using ColizeumDaily.Models;

namespace ColizeumDaily.Interfaces;

public interface IAdminManageService
{
    public UserModel UserGet(string UserNumber);
    
    public string UserStockGet(string UserNumber);
    
    public void UserVisitCheck(string UserNumber);

    public void NightPacksCheck(string UserNumber);
    
    public void UserReg(string UserNumber, string TelegramUsername);
}