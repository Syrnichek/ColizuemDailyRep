using ColizeumDaily.Interfaces;
using ColizeumDaily.Models;
using Microsoft.AspNetCore.Mvc;

namespace ColizeumDaily.Controllers;

public class ManageStockController : Controller
{
    private readonly IManageStockService _manageStockService;

    public ManageStockController(IManageStockService manageStockService)
    {
        _manageStockService = manageStockService;
    }
    
    [HttpGet]
    [Route("api/manageStock/stockChange")]
    public IActionResult StockChange(int daysStreak, string stockDescription)
    {
        try
        {
            _manageStockService.StockChange(daysStreak, stockDescription);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(251, "Ошибка при попытке изменить описание акции");
        }
    }
    
    [HttpGet]
    [Route("api/manageStock/stocksGet")]
    public List<StockModel> StocksGet()
    {

        return _manageStockService.StocksGet();
    }
}