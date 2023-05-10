using ColizeumDaily.Exceptions;
using ColizeumDaily.Interfaces;
using ColizeumDaily.Models;
using Microsoft.EntityFrameworkCore;

namespace ColizeumDaily.Services;

public class AdminManageService : IAdminManageService
{
    private readonly ILogger<UserManageService> _logger;
    private readonly IManageStockService _manageStockService;
    
    public AdminManageService(ILogger<UserManageService> logger, IManageStockService manageStockService)
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

            StockModel stocks = _manageStockService.StocksGet().OrderByDescending(s => s.daysstreak).FirstOrDefault();
            
            if (user.visitdate.Date == DateTime.Now.Date)
            {
                throw new UserAlreadyCheckException("User is already checked");
            }
            
            if (user.daysstreak >= stocks.daysstreak)
            {
                throw new MaximumStockException("User has maximum stock");
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

            if (user.nightpacksstreak >= 3)
            {
                throw new MaximumNightPacksException("User has maximum night packs");
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