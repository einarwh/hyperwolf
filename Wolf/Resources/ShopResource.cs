using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

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
            var weaponValues = form["item"];
            if (weaponValues == StringValues.Empty) 
            {
                throw new ClientErrorException("You must choose an item!");
            }
            else 
            {
                var thingId = form["item"][0];
                return _shop.Purchase(_game.Player, thingId);
            }
        }
    }
}
