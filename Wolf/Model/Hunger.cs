using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Wolf
{
    public class Hunger : IHostedService
    {
        private readonly Game _game;
        private readonly TimeSpan _refreshInterval = TimeSpan.FromSeconds(30);

        private Timer _timer;

        public Hunger(Game game)
        {
            _game = game;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(_ => AffectPlayer(),
                null,
                TimeSpan.Zero,
                _refreshInterval);
            return Task.CompletedTask;
        }

        private void AffectPlayer()
        {
            if (_game.Player != null)
            {
                _game.Player.FeelHungry();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, Timeout.Infinite);
            return Task.CompletedTask;
        }
    }
}