using System;
using System.Collections.Generic;
using System.Linq;

namespace Wolf
{
    public class Shop : Place
    {
        private readonly List<ThingForPurchase> _stock;

        public override string Id => "/shop";

        public override string Title => "The Shop";

        public Shop()
        {
            _stock = new List<ThingForPurchase>
            {
                new ThingForPurchase(new Torch(), new Money(15)),
                new ThingForPurchase(new FoodRation(), new Money(2)),
                new ThingForPurchase(new Axe(), new Money(10)),
                new ThingForPurchase(new Sword(), new Money(20)),
                new ThingForPurchase(new MagicAmulet(), new Money(30)),
                new ThingForPurchase(new SuitOfArmor(), new Money(50)),
            };
        }

        public override Representation Visit(Player player)
        {
            var fields = _stock.Select(item => ToItemField(item)).ToList();
            var action = new Action("purchase-item", "POST", "/shop", "Make purchase");
            foreach (var f in fields)
            {
                action.AddField(f);
            }

            var playerItems = player.Inventory.Select(it => it.ToString()).ToArray();
            var properties = new Dictionary<string, object>();
            properties.Add("Your wealth is", player.Wealth.ToString());
            if (playerItems.Any())
            {
                properties.Add("You are carrying", playerItems);
            }

            return new Representation
            {
                Title = new Title(Title),
                Description = new Description("Stock up on things to help you."),
                Properties = properties,
                Links = new List<Link>
                    {
                        new Link("self", Id),
                        new Link("back", "/location")
                    },
                Actions = new List<Action>
                {
                    action
                }
            };
        }

        private ThingForPurchase Lookup(string thingId)
        {
            var stockItem = _stock.FirstOrDefault(it => thingId == it.Thing.Id);
            if (stockItem == null)
            {
                throw new Exception($"No such item: {thingId}");
            }

            return stockItem;
        }

        public Representation Purchase(Player player, string thingId)
        {
            var stockItem = Lookup(thingId);
            player.Buy(stockItem);
            return Visit(player);
        }

        private static Field ToItemField(ThingForPurchase item)
        {
            var field = new Field("item")
            {
                Type = "radio",
                Value = item.Thing.Id,
                Title = item.ToString()
            };
            return field;
        }
    }
}
