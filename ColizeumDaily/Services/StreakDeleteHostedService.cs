using ColizeumDaily.Models;
using Microsoft.EntityFrameworkCore;

namespace ColizeumDaily.Services
{
    public class StreakDeleteHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<StreakDeleteHostedService> _logger;
        private Timer? _timer = null;
        private int weeksCount; 
        
        public StreakDeleteHostedService(ILogger<StreakDeleteHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Streak Delete Hosted Service running");
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(0.2));
            return Task.CompletedTask;
        }
        
        private void DoWork(object? state)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder.Options;
            var applicationContext = new ApplicationContext(options); 
         
            var todayDate = DateTime.Now; 
            var todayDateUtc = DateTime.UtcNow; 
            var today = todayDate.DayOfWeek;

            var weeks = new WeeksModel();
            
            if (today == DayOfWeek.Monday && todayDate.Hour == 0)
            {
                _logger.LogInformation("Количество недель: " + weeksCount);
                weeksCount++;
                if (weeksCount == 3)
                {
                    foreach (var user in applicationContext.users.Where(user => user.daysstreak > 0))
                    {
                        user.daysstreak = 0;
                    }

                    _logger.LogInformation("Очистка стрика произведена");

                    foreach (var user in applicationContext.users.Where(user => user.nightpacksstreak > 4))
                    {
                        user.nightpacksstreak = 0;
                    }
                    
                    _logger.LogInformation("Очистка стрика ночных пакетов призведена");
                    
                    while (weeks.id < 14)
                    {
                        weeks.weeksdate = todayDate;
                        weeks.id++;
                        todayDate = todayDate.AddDays(weeks.id);
                    }
                    
                    _logger.LogInformation("Отсос призведён");

                    weeksCount = 0;
                }
            }
            _logger.LogInformation("Streak Delete Hosted Service running");
        }
        
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Streak Delete Hosted Service is stopping");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}