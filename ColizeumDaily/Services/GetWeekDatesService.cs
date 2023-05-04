using ColizeumDaily.Interfaces;
using ColizeumDaily.Models;
using Microsoft.EntityFrameworkCore;

namespace ColizeumDaily.Services;

public class GetWeekDatesService : IGetWeekDatesService
{
    private ILogger<GetWeekDatesService> _logger;

    public GetWeekDatesService(ILogger<GetWeekDatesService> logger)
    {
        _logger = logger;
    }

    public WeeksModel GetWeekDates()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        var options = optionsBuilder.Options;
        var weeks = new WeeksModel();
        
        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            foreach (var w in applicationContext.weeks)
            {
                weeks = w;
            }
        }

        return weeks;
    }
}