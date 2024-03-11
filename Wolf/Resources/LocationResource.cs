using System;
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
            if (_game.Player == null) 
            {
                var redirectTo = $"/start";
                throw new RedirectException(302, redirectTo);
            }
            else {
                var location = _game.Player.Location;
                var redirectTo = $"/{_game.GameId}{location.Id}";
                throw new RedirectException(302, redirectTo);
            }
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
            throw new RedirectException(302, $"/{_game.GameId}{destination.Id}");
        }
    }
}
