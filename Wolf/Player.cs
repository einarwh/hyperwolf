using System;
using System.Collections.Generic;
using System.Linq;

namespace Wolf
{
    public class ClientErrorException : Exception
    {
        public ClientErrorException(string message) : base(message) { }
    }

    public class Player
    {
        private readonly List<Thing> _inventory = new List<Thing>();

        private Money _wealth;
        private Health _health;

        public Player()
        {
            _wealth = new Money(75);
            _health = new Health(100);
        }

        public bool HasLight
        {
            get
            {
                return _inventory.Exists(it => it is Torch);
            }
        }

        public Money Wealth => _wealth;

        public Health Health => _health;

        public Place Location { get; set; }

        public void Keep(Thing thing)
        {
            if (thing is Treasure treasure)
            {
                _wealth = _wealth + treasure.Worth;
            }
            else
            {
                _inventory.Add(thing);
            }
        }

        public void Drop(Thing thing)
        {
            _inventory.Remove(thing);
        }

        private FoodSupply LookupFoodSupply()
        {
            var foodSupplyItem = _inventory.FirstOrDefault(it => it.Id == "food-supply");
            return foodSupplyItem as FoodSupply;
        }

        public void Eat()
        {
            var foodSupply = LookupFoodSupply();
            if (foodSupply.IsEmpty)
            {
                throw new Exception("You have no food!");
            }
            else
            {
                foodSupply.Decrement();
                _health = _health + new Health(5);
            }
        }

        public IEnumerable<Thing> Inventory => _inventory;

        public Representation Introspect()
        {
            var inventory = _inventory.Select(thing => thing.ToString()).ToArray();

            return new Representation
            {
                Title = new Title("The Player"),
                Description = new Description("The bold hero of this adventure."),
                Properties = new Dictionary<string, object>
                {
                    ["location"] = Location.Title,
                    ["health"] = _health,
                    ["wealth"] = _wealth,
                    ["inventory"] = inventory
                },
                Links = new List<Link>
                    {
                        new Link("self", "/player"),
                        new Link("back", "/location")
                    }
            };
        }

        public void Buy(ThingForPurchase stockItem)
        {
            var thing = stockItem.Thing;
            var price = stockItem.Price;
            if (price > _wealth)
            {
                throw new ClientErrorException("You can't afford that!");
            }
            _wealth = _wealth - price;
            if (thing is FoodRation)
            {
                var foodSupply = LookupFoodSupply();
                if (foodSupply == null)
                {
                    foodSupply = new FoodSupply();
                    Keep(foodSupply);
                }

                foodSupply.Increment();
            }
            else
            {
                Keep(thing);
            }
        }
    }

}
