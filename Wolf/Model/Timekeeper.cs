using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Wolf
{
    public class Timekeeper : IHostedService
    {
        private readonly MainRequestHandler _main;
        private readonly TimeSpan _refreshInterval = TimeSpan.FromSeconds(30);

        private Timer _timer;

        public Timekeeper(MainRequestHandler main)
        {
            _main = main;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(_ => Tick(),
                null,
                TimeSpan.Zero,
                _refreshInterval);
            return Task.CompletedTask;
        }

        private void Tick()
        {
            if (_main != null) 
            {
                _main.Tick();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, Timeout.Infinite);
            return Task.CompletedTask;
        }
    }
}