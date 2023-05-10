using ColizeumDaily.Models;

namespace ColizeumDaily.Interfaces;

public interface IUserManageService
{
    public UserModel UserGet(string UserNumber);

    public string UserStockGet(string UserNumber);
}