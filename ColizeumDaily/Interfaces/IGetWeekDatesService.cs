using ColizeumDaily.Models;

namespace ColizeumDaily.Interfaces;

public interface IGetWeekDatesService
{
    public List<WeeksModel> GetWeekDates();
}