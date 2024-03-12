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
        private readonly string _name;
        private readonly List<Thing> _inventory = new List<Thing>();

        private Money _wealth;
        private Health _health;

        private bool _won;

        private string _causeOfDeath;

        public Player(string name)
        {
            _name = name;
            _wealth = new Money(75);
            _health = new Health(100);
            _won = false;
        }

        public string Name => _name;

        public bool HasLight => _inventory.Exists(it => it is Torch);

        public bool HasAmulet => _inventory.Exists(it => it is MagicAmulet);

        public bool IsAlive => _health > new Health(0);

        public bool HasWon => _won;

        public Money Wealth => _wealth;

        public Health Health => _health;

        public Place Location { get; set; }

        public string CauseOfDeath
        {
            get
            {
                if (IsAlive)
                {
                    throw new Exception("You're not dead!");
                }
                else
                {
                    return _causeOfDeath;
                }
            }
        }

        public void FeelHungry()
        {
            if (IsAlive && !HasWon) {
                _health = _health - new Health(5);
                if (_health < new Health(1))
                {
                    _health = new Health(0);
                    _causeOfDeath = "You died from starvation.";
                }
            }
        }

        public void Win()
        {
            _won = true;
        }

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

        private FoodSupply LookupFoodSupply()
        {
            var foodSupplyItem = _inventory.FirstOrDefault(it => it.Id == "food-supply");
            return foodSupplyItem as FoodSupply;
        }

        public void Wound(Health wound, Monster monster)
        {
            if (IsAlive && !HasWon) {
                _health = _health - wound;
                if (_health < new Health(1))
                {
                    _health = new Health(0);
                    _causeOfDeath = $"You were killed by the {monster.Title}.";
                }
            }
        }

        public void Eat()
        {
            var foodSupply = LookupFoodSupply();
            if (foodSupply is null || foodSupply.IsEmpty)
            {
                throw new Exception("You have no food!");
            }
            else
            {
                foodSupply.Decrement();
                _health += new Health(5);
                if (foodSupply.IsEmpty)
                {
                    _inventory.Remove(foodSupply);
                }
            }
        }

        public IEnumerable<Thing> Inventory => _inventory;

        public IEnumerable<Weapon> Weapons 
        {
            get
            {
                var weapons = _inventory.Where(it => it is Weapon).Cast<Weapon>();
                return weapons.Any() ? weapons : new List<Weapon> { new BareHands() };
            }
        }

        public bool IsWeak => _health < new Health(25);

        public bool HasArmor => _inventory.Exists(it => it is SuitOfArmor);

        public Representation Introspect()
        {
            var inventory = _inventory.Select(thing => thing.ToString()).ToArray();

            var foodSupply = LookupFoodSupply();
            var actions = new List<Action>();
            if (foodSupply != null && !foodSupply.IsEmpty)
            {
                actions.Add(new Action("eat", "POST", "/player", "Eat a food ration"));
            }

            return new Representation
            {
                Title = new Title("The Player"),
                Description = new Description($"You are {_name}, the bold hero of this adventure."),
                Properties = new Dictionary<string, object>
                {
                    ["Location"] = Location.Title,
                    ["Health"] = _health,
                    ["Wealth"] = _wealth,
                    ["Inventory"] = inventory
                },
                Links = new List<Link>
                    {
                        new Link("self", "/player"),
                        new Link("back", "/location")
                    },
                Actions = actions
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
