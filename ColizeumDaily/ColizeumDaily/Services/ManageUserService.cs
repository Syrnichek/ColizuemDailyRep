using ColizeumDaily.Models;
using ColizeumDaily.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ColizeumDaily.Services;

public class ManageUserService : IManageUserService
{
    
    public UserModel UserGet(string Username)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
        var options = optionsBuilder.Options;

        ApplicationContext applicationContext = new ApplicationContext(options);
        UserModel user = applicationContext.users.FirstOrDefault(u => u.username == Username);
        return user;
    }

    public void UserVisitCheck(string Username)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
        var options = optionsBuilder.Options;
        
        ApplicationContext applicationContext = new ApplicationContext(options);
        var user = UserGet(Username);
        user.daysstreak++;
        user.visitdate = DateTime.UtcNow.AddHours(3);
        applicationContext.users.Update(user);
        applicationContext.SaveChanges();
    }

    public void UserReg(string Username, string TelegramUsername)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
        var options = optionsBuilder.Options;
        
        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            UserModel user = new UserModel { username = Username, telegramusername = TelegramUsername};
            applicationContext.users.Add(user);
            applicationContext.SaveChanges();
        }
    }
    
    public void StreakDelete() 
    { 
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>(); 
         
        var options = optionsBuilder.Options; 
         
        var applicationContext = new ApplicationContext(options); 
         
        var todayDate = DateTime.Now; 
        var today = todayDate.DayOfWeek; 
 
        if (today == DayOfWeek.Monday && todayDate.Hour == 0) 
        { 
            foreach (var user in applicationContext.users.Where(user => user.daysstreak > 0)) 
            { 
                user.daysstreak = 0; 
            } 
            applicationContext.SaveChanges(); 
        } 
    } 
}