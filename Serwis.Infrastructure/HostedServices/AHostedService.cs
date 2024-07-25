using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;


namespace Serwis.Infrastructure.HostedServices
{
    public abstract class AHostedService : IHostedService
    {
        private DateTime _nextRun;
        private Task _executingTask = null!;
        public abstract DateTime NextScheduledOperation { get; }
        protected readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly CancellationTokenSource _stoppingCts = new();

        protected AHostedService(IServiceScopeFactory serviceScopeFactory) : base()
        {
            _nextRun = DateTime.Now.AddSeconds(1);
            _serviceScopeFactory = serviceScopeFactory;
        }

        public virtual async Task StartAsync(CancellationToken cancellationToken)
        {
            await ExecuteAsync(_stoppingCts.Token);
        }

        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_executingTask == null)
                return;

            try
            {
                _stoppingCts.Cancel();
            }
            finally
            {
                _ = await Task.WhenAny(_executingTask, Task.Delay(Timeout.Infinite, cancellationToken));
            }
        }

        protected async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                await Task.Delay(1000, stoppingToken);

                if (DateTime.Now <= _nextRun)
                    continue;

                try
                {
                    _executingTask = Process();
                    await _executingTask;
                }
                catch (Exception ex)
                {
                    //Tutaj umieścić logowanie błędów serwisu
                }

                _nextRun = NextScheduledOperation;
            } while (true);
        }

        protected async Task Process()
        {
            using IServiceScope scope = _serviceScopeFactory.CreateScope();
            await BaseServiceHandler(scope.ServiceProvider);
        }

        public abstract Task BaseServiceHandler(IServiceProvider scopeServiceProvider);
    }
}