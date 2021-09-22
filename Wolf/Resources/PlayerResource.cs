using Microsoft.AspNetCore.Http;

namespace Wolf
{
    public class PlayerResource : Resource
    {
        private readonly Game _game;

        public PlayerResource(Game game)
        {
            _game = game;
        }

        protected override Representation Get(HttpContext context)
        {
            return _game.Player.Introspect();
        }
    }
}
