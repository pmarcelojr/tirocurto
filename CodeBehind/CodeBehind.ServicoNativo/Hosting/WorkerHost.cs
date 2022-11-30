using System.Threading;

namespace CodeBehind.ServicoNativo.Hosting
{
    public sealed class WorkerHost : IHostedService, IAsyncDisposable
    {
        private readonly Task _completeTask = Task.CompletedTask;
        private readonly ILogger<WorkerHost> _logger;
        private int _executionCount = 0;
        private Timer? _timer;

        public WorkerHost(ILogger<WorkerHost> logger) => _logger = logger;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("{ServiceName} is starting.", nameof(WorkerHost));
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return _completeTask;
        }

        private void DoWork(object? state)
        {
            int count = Interlocked.Increment(ref _executionCount);

            _logger.LogInformation("{ServiceName} is working. execution count: {Count}", nameof(Worker), count);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("{ServiceName} is stopping.", nameof(Worker));

            _timer?.Change(Timeout.Infinite, 0);

            return _completeTask;
        }

        public async ValueTask DisposeAsync()
        {
            if (_timer is IAsyncDisposable timer)
            {
                await timer.DisposeAsync();
            }

            _timer = null;
        }
    }
}
