using ColizeumDaily.Interfaces;
using ColizeumDaily.Models;
using Microsoft.EntityFrameworkCore;

namespace ColizeumDaily.Services;

public class GetWeekDatesService : IGetWeekDatesService
{

    public List<WeeksModel> GetWeekDates()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        var options = optionsBuilder.Options;
        
        using (ApplicationContext applicationContext = new ApplicationContext(options))
        {
            IEnumerable<WeeksModel> weeksIEnumerable = applicationContext.weeks;
            return weeksIEnumerable.ToList();
        }
    }
}