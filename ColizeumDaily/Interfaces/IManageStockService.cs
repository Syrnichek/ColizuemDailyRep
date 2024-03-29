using ColizeumDaily.Models;

namespace ColizeumDaily.Interfaces;

public interface IManageStockService
{
    public void StockChange(int daysStreak, string stockDescription);

    public List<StockModel> StocksGet();

    public void StockAdd(int daysStreak, string stockDescription);

    public void StockDelete(int daysStreak);
}