using System;
using System.Linq;
using ColizeumDaily.Models;

namespace ColizeumDaily.Services;

public class ManageUserService : IManageUserService
{
    public void UserGet(string Username)
    {

    }

    public void UserVisitCheck(string Username)
    {
        
    }

    public void UserReg(string Username, string TelegramUsername)
    {
        using (ApplicationContext applicationContext = new ApplicationContext())
        {
            UserModel user = new UserModel { Username = Username, TelegramUsername = TelegramUsername};
            applicationContext.Users.Add(user);
            applicationContext.SaveChanges();
        }
    }
}