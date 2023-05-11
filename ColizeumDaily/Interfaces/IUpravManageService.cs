using ColizeumDaily.Models;

namespace ColizeumDaily.Interfaces;

public interface IUpravManageService
{
    public void UpravLogin(string UpravName, string UpravPassword, int ClubId);

    public void AdminAdd(string AdminName, string AdminPassword);

    public AdminModel[] AdminsGet();
}