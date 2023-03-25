using ColizeumDaily.Models;

namespace ColizeumDaily.Interfaces;

public interface IManageStockService
{
    public void StockChange(int daysstreak);

    public void StockAdd(int daysstreak, string stockdescription);

    public void StockDelete(int daysstreak);
}