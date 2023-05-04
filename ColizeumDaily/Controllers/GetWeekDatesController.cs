using ColizeumDaily.Interfaces;
using ColizeumDaily.Models;
using Microsoft.AspNetCore.Mvc;

namespace ColizeumDaily.Controllers;

public class GetWeekDatesController : Controller
{
    private readonly IGetWeekDatesService _getWeekDatesService;
    
    public GetWeekDatesController(IGetWeekDatesService getWeekDatesService)
    {
        _getWeekDatesService = getWeekDatesService;
    }
    
    [HttpGet]
    [Route("api/getWeekDates/getDates")]
    public WeeksModel GetDates()
    {

        return _getWeekDatesService.GetWeekDates();
    }
}