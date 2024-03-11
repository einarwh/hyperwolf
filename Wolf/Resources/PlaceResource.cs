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
            return _place.Visit(_game);
        }

        protected override Representation Post(HttpContext context)
        {
            var form = context.Request.Form;
            if (form.Count > 0) 
            {
                var thingId = form["item"][0];
                return _place.PickUp(_game, thingId);
            } 
            else 
            {
                throw new ClientErrorException("You didn't select an item!");
            }
        }
    }
}
