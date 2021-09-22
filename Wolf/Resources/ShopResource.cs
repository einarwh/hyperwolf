using Microsoft.AspNetCore.Http;

namespace Wolf
{
    public class ShopResource : Resource
    {
        private readonly Game _game;
        private readonly Shop _provisions;

        public ShopResource(Game game, Shop provisions)
        {
            _game = game;
            _provisions = provisions;
        }

        protected override Representation Get(HttpContext context)
        {
            return _provisions.Visit(_game.Player);
        }

        protected override Representation Post(HttpContext context)
        {
            var form = context.Request.Form;
            var thingId = form["item"][0];
            return _provisions.Purchase(_game.Player, thingId);
        }
    }
}
