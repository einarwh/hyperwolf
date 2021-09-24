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
            throw new RedirectException(302, id);
        }
    }

    public class TeleportResource : Resource
    {
        private readonly Game _game;

        public TeleportResource(Game game)
        {
            _game = game;
        }

        protected override Representation Get(HttpContext context)
        {
            var random = _game.Random;
            var rooms = _game.RegularRooms;
            var index = random.Next(0, rooms.Count);
            var destination = rooms[index];
            throw new RedirectException(302, destination.Id);
        }
    }
}
