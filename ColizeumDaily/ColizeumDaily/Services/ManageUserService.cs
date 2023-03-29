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

    public string UserStockGet(string UserNumber)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        var options = optionsBuilder.Options;

        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            var user = UserGet(UserNumber);

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

            var stocksList = _manageStockService.StocksGet();
            var stocksMax = stocksList
            
            if (user.visitdate.Date == DateTime.Now.Date)
            {
                throw new Exception("User is already checked");
            }

            if (user.daysstreak <= stocksMax)
            {
                user.daysstreak++;
                user.visitdate = DateTime.UtcNow.AddHours(3);
                applicationContext.users.Update(user);
                applicationContext.SaveChanges();
            }
            else
            {
                throw new Exception("User has maximum stock");
            }
        }
    }

    public void NightPacksCheck(string UserNumber)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
        var options = optionsBuilder.Options;

        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            var user = UserGet(UserNumber);
            
            if (user.nightpackvisitdate.Date == DateTime.Now.Date)
            {
                throw new Exception("User is already checked");
            }
            user.nightpacksstreak++;
            user.nightpackvisitdate = DateTime.UtcNow.AddHours(3);
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