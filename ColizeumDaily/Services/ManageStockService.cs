using ColizeumDaily.Interfaces;
using ColizeumDaily.Models;
using Microsoft.EntityFrameworkCore;

namespace ColizeumDaily.Services;

public class ManageStockService : IManageStockService
{
    private readonly ILogger<ManageStockService> _logger;
    
    public ManageStockService(ILogger<ManageStockService> logger)
    {
        _logger = logger;
    }
    
    public void StockChange(int daysStreak, string stockDescription)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        var options = optionsBuilder.Options;

        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            StockModel stock = applicationContext.stocks.FirstOrDefault(s => s.daysstreak == daysStreak);
            stock.stockdescription = stockDescription;
            applicationContext.stocks.Update(stock);
            applicationContext.SaveChanges();
        }
    }

    public List<StockModel> StocksGet()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        var options = optionsBuilder.Options;

        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            IQueryable<StockModel> stockIQueryable = applicationContext.stocks;
            var stocks = stockIQueryable.Where(p => p.daysstreak != null).ToList();
            return stocks;
        }
    }

    public void StockAdd(int daysstreak, string stockdescription)
    {
        throw new NotImplementedException();
    }

    public void StockDelete(int id)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
 
        var options = optionsBuilder.Options;

        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            StockModel stock = applicationContext.stocks.FirstOrDefault(s => s.id == id);
            if (stock != null)
            {
                applicationContext.stocks.Remove(stock);
                applicationContext.SaveChanges();
            }
        }
    }
}