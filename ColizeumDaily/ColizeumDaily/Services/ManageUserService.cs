using ColizeumDaily.Models;
using ColizeumDaily.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ColizeumDaily.Services;

public class ManageUserService : IManageUserService
{
    
    
    
    public UserModel UserGet(int UserNumber)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
        var options = optionsBuilder.Options;

        ApplicationContext applicationContext = new ApplicationContext(options);
        UserModel user = applicationContext.users.FirstOrDefault(u => u.usernumber == UserNumber);
        return user;
    }

    public void UserVisitCheck(int UserNumber)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
        var options = optionsBuilder.Options;
        
        ApplicationContext applicationContext = new ApplicationContext(options);
        var user = UserGet(UserNumber);
        user.daysstreak++;
        user.visitdate = DateTime.UtcNow.AddHours(3);
        applicationContext.users.Update(user);
        applicationContext.SaveChanges();
    }

    public void NightPacksCheck(int UserNumber)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
        var options = optionsBuilder.Options;
        
        ApplicationContext applicationContext = new ApplicationContext(options);
        var user = UserGet(UserNumber);
        user.nightpacksstreak++;
        user.visitdate = DateTime.UtcNow.AddHours(3);
        applicationContext.users.Update(user);
        applicationContext.SaveChanges();
    }

    public void UserReg(int UserNumber, string TelegramUserName)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
        var options = optionsBuilder.Options;
        
        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            UserModel user = new UserModel { usernumber = UserNumber, telegramusername = TelegramUserName};
            applicationContext.users.Add(user);
            applicationContext.SaveChanges();
        }
    }
}