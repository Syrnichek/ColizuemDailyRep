using Microsoft.EntityFrameworkCore;

namespace ColizeumDaily.Services
{
    public class StreakDeleteHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<StreakDeleteHostedService> _logger;
        
        public StreakDeleteHostedService(ILogger<StreakDeleteHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Streak Delete Hosted Service running");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}