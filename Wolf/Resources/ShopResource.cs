using Microsoft.AspNetCore.Http;

namespace Wolf
{
    public class ShopResource : Resource
    {
        private readonly Game _game;
        private readonly Shop _shop;

        public ShopResource(Game game)
        {
            _game = game;
            _shop = _game.Shop;
        }

        protected override Representation Get(HttpContext context)
        {
            return _shop.Visit(_game.Player);
        }

        protected override Representation Post(HttpContext context)
        {
            var form = context.Request.Form;
            var thingId = form["item"][0];
            return _shop.Purchase(_game.Player, thingId);
        }
    }
}
