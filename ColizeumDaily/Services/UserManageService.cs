using ColizeumDaily.Exceptions;
using ColizeumDaily.Models;
using ColizeumDaily.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace ColizeumDaily.Services;

public class UserManageService : IUserManageService
{
    private readonly ILogger<UserManageService> _logger;
    
    public UserManageService(ILogger<UserManageService> logger, IManageStockService manageStockService)
    {
        _logger = logger;
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
}