using ColizeumDaily.Models;
using Microsoft.EntityFrameworkCore;

namespace ColizeumDaily.Services;

public class GetWeeksHostedService : IHostedService, IDisposable
{
    private readonly ILogger<GetWeeksHostedService> _logger;
    private Timer? _timer = null;
    private int weeksCount;
    
    public GetWeeksHostedService(ILogger<GetWeeksHostedService> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get Weeks Hosted Service running");
        _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromMinutes(0.2));
        return Task.CompletedTask;
    }
    
    private void DoWork(object? state)
    {
        var todayDate = DateTime.Now; 
        var today = todayDate.DayOfWeek;
        var todayDateUtc = DateTime.UtcNow; 
        
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        var options = optionsBuilder.Options;
        var applicationContext = new ApplicationContext(options);

        var weeks = new WeeksModel();
        
        if (today == DayOfWeek.Monday && todayDate.Hour == 0)
        {
            _logger.LogInformation("Количество недель: " + weeksCount);
            weeksCount++;
            if (weeksCount == 3)
            {
                applicationContext.weeks.ExecuteDelete();
                
                while (weeks.id < 14)
                {
                    weeks.weeksdate = todayDateUtc.AddHours(3);
                    weeks.id++;
                    todayDateUtc = todayDateUtc.AddDays(1);
                    applicationContext.weeks.Add(weeks);
                    applicationContext.SaveChanges();
                }
                weeksCount = 0;
                
                _logger.LogInformation("Дни записаны в базу данных");
            }
        }
        
        _logger.LogInformation("Get Weeks Hosted Service running");
    }
    
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get Weeks Hosted Service is stopping");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}