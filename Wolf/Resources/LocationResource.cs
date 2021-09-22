using Microsoft.AspNetCore.Http;

namespace Wolf
{
    public class LocationResource : Resource
    {
        private readonly Game _game;

        public LocationResource(Game game)
        {
            _game = game;
        }

        protected override Representation Get(HttpContext context)
        {
            var location = _game.Player.Location;
            var id = location.Id;
            throw new RedirectException(id);
        }
    }
}
