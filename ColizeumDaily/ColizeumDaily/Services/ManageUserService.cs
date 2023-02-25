using ColizeumDaily.Models;
using ColizeumDaily.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ColizeumDaily.Services;

public class ManageUserService : IManageUserService
{
    private readonly ILogger<ManageUserService> _logger;
    
    public ManageUserService(ILogger<ManageUserService> logger)
    {
        _logger = logger;
    }

    public UserModel UserGet(string UserNumber)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        var options = optionsBuilder.Options;

        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            UserModel user = applicationContext.users.FirstOrDefault(u => u.usernumber == UserNumber);
            if (user == null)
                _logger.LogInformation("Введите правильное значение номера");
            return user;
        }
    }

    public void UserVisitCheck(string UserNumber)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
        var options = optionsBuilder.Options;

        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            var user = UserGet(UserNumber);
            
            user.daysstreak++;
            user.visitdate = DateTime.UtcNow.AddHours(3);
            applicationContext.users.Update(user);
            applicationContext.SaveChanges();
        }
    }

    public void NightPacksCheck(string UserNumber)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
        var options = optionsBuilder.Options;

        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            var user = UserGet(UserNumber);
            if (user.visitdate.Date == DateTime.Now.Date)
            {
                throw new Exception("User is already checked");
            }
            user.nightpacksstreak++;
            user.visitdate = DateTime.UtcNow.AddHours(3);
            applicationContext.users.Update(user);
            applicationContext.SaveChanges();
        }
    }

    public void UserReg(string UserNumber, string TelegramUserName)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
        var options = optionsBuilder.Options;

        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            if (applicationContext.users.FirstOrDefault(u => u.usernumber == UserNumber) != null)
            {
                throw new Exception("User already exists");
            }

            UserModel user = new UserModel { usernumber = UserNumber, telegramusername = TelegramUserName };
            applicationContext.users.Add(user);
            applicationContext.SaveChanges();
        }
    }
}