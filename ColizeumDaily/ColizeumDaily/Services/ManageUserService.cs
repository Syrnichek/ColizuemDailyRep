using ColizeumDaily.Exceptions;
using ColizeumDaily.Models;
using ColizeumDaily.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace ColizeumDaily.Services;

public class ManageUserService : IManageUserService
{
    private readonly ILogger<ManageUserService> _logger;
    private readonly IManageStockService _manageStockService;
    
    public ManageUserService(ILogger<ManageUserService> logger, IManageStockService manageStockService)
    {
        _logger = logger;
        _manageStockService = manageStockService;
    }

    public UserModel UserGet(string userNumber)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        var options = optionsBuilder.Options;

        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            UserModel user = applicationContext.users.FirstOrDefault(u => u.usernumber == userNumber);
            if (user == null)
                _logger.LogInformation("Введите правильное значение номера");
            return user;
        }
    }

    public string UserStockGet(string userNumber)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        var options = optionsBuilder.Options;

        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            var user = UserGet(userNumber);

            StockModel stock = applicationContext.stocks.FirstOrDefault(s => s.daysstreak == user.daysstreak);
            return stock.stockdescription;
        }
    }

    public void UserVisitCheck(string UserNumber)
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
            user.daysstreak++;
            user.visitdate = DateTime.UtcNow.AddHours(3);
            applicationContext.users.Update(user);
            applicationContext.SaveChanges();
        }
    }

    public void NightPacksCheck(string userNumber)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
        var options = optionsBuilder.Options;

        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            var user = UserGet(userNumber);
            
            if (user.nightpackvisitdate.Date == DateTime.Now.Date)
            {
                throw new UserAlreadyCheckException("User is already checked");
            }
            user.nightpacksstreak++;
            user.nightpackvisitdate = DateTime.UtcNow.AddHours(3);
            applicationContext.users.Update(user);
            applicationContext.SaveChanges();
        }
    }

    public void UserReg(string userNumber, string telegramUserName)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
        var options = optionsBuilder.Options;

        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            if (applicationContext.users.FirstOrDefault(u => u.usernumber == userNumber) != null)
            {
                throw new UserAlreadyExistsException("User already exists");
            }

            UserModel user = new UserModel { usernumber = userNumber, telegramusername = telegramUserName };
            applicationContext.users.Add(user);
            applicationContext.SaveChanges();
        }
    }
}