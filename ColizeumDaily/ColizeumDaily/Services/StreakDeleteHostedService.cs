using Microsoft.EntityFrameworkCore;

namespace ColizeumDaily.Services
{
    public class StreakDeleteHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<StreakDeleteHostedService> _logger;
        private Timer? _timer = null;
        
        public StreakDeleteHostedService(ILogger<StreakDeleteHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Streak Delete Hosted Service running");
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromHours(1));
            return Task.CompletedTask;
        }
        
        private void DoWork(object? state)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>(); 
         
            var options = optionsBuilder.Options; 
         
            var applicationContext = new ApplicationContext(options); 
         
            var todayDate = DateTime.Now; 
            var today = todayDate.DayOfWeek; 
 
            if (today == DayOfWeek.Monday && todayDate.Hour == 0) 
            { 
                foreach (var user in applicationContext.users.Where(user => user.daysstreak > 0)) 
                { 
                    user.daysstreak = 0; 
                } 
                applicationContext.SaveChanges(); 
                _logger.LogInformation("Очистка стрика произведена");
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