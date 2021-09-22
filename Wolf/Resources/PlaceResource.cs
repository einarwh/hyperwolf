using Microsoft.AspNetCore.Http;

namespace Wolf
{
    public class PlaceResource : Resource
    {
        private readonly Game _game;
        private readonly Place _place;

        public PlaceResource(Game game, Place place)
        {
            _game = game;
            _place = place;
        }

        protected override Representation Get(HttpContext context)
        {
            return _place.Visit(_game.Player);
        }

        protected override Representation Post(HttpContext context)
        {
            var form = context.Request.Form;
            var thingId = form["item"][0];
            return _place.PickUp(_game.Player, thingId);
        }
    }
}
