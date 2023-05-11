using ColizeumDaily.Interfaces;
using ColizeumDaily.Models;

namespace ColizeumDaily.Services;

public class UpravManageService : IUpravManageService
{
    private UpravManageService()
    {
        
    }
    
    public void UpravLogin(string UpravName, string UpravPassword, int ClubId)
    {
        
    }

    public void AdminAdd(string AdminName, string AdminPassword)
    {
        throw new NotImplementedException();
    }

    public AdminModel[] AdminsGet()
    {
        throw new NotImplementedException();
    }
}