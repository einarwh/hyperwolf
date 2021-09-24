using Microsoft.AspNetCore.Http;

namespace Wolf
{
    public class DeathResource : Resource
    {
        private readonly Game _game;
        private readonly PlayerDeath _death;

        public DeathResource(Game game)
        {
            _game = game;
            _death = new PlayerDeath();
        }

        protected override Representation Get(HttpContext context)
        {
            return _death.Summary(_game.Player);
        }
    }
}
