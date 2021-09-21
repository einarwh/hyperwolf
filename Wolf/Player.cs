using System.Collections.Generic;
using System.Linq;

namespace Wolf
{
    public class Player
    {
        private readonly List<Thing> _inventory = new List<Thing>();

        private int _wealth;
        private int _health;

        public Player()
        {
            _wealth = 75;
            _health = 100;
        }

        public bool HasLight
        {
            get
            {
                return _inventory.Exists(it => it is Torch);
            }
        }

        public int Wealth => _wealth;

        public int Health => _health;

        public void Keep(Thing thing)
        {
            _inventory.Add(thing);
        }

        public void Drop(Thing thing)
        {
            _inventory.Remove(thing);
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
                    ["health"] = _health,
                    ["wealth"] = _wealth,
                    ["inventory"] = inventory
                },
                Links = new List<Link>
                    {
                        new Link("self", "player"),
                        new Link("back", "location")
                    }
            };
        }
    }
}
