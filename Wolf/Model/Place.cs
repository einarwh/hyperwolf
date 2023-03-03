using System;
using System.Collections.Generic;
using System.Linq;

namespace Wolf
{
    public abstract class Place
    {
        private readonly List<Thing> _things = new List<Thing>();

        private readonly List<Monster> _monsters = new List<Monster>();

        public abstract string Id { get; }

        public abstract string Title { get; }

        public abstract string Description(Player player);

        public virtual List<Link> NavigationLinks => new List<Link>();

        public virtual List<Link> GenericLinks =>
            new List<Link>
            {
                new Link("self", Id),
                new Link("player", "/player"),
                new Link("shop", "/shop")
            };

        public virtual List<Link> Links(Player player) 
        {
            if (Monsters.Any())
            {
                var monster = Monsters.First();
                var result = new List<Link>();
                result.Add(new Link("fight", monster.Id));
                return result;
            }
            else
            {
                var result = new List<Link>();
                result.AddRange(GenericLinks);
                if (player.HasAmulet)
                {
                    result.Add(new Link("teleport", "/teleport"));
                }
                result.AddRange(NavigationLinks);
                return result;
            }
        }

        public List<Action> Actions(Player player)
        {
            if (Monsters.Any(it => it.IsAlive))
            {
                return new List<Action>();
            }
            else
            {
                var actions = new List<Action>();
                if (Things.Any())
                {
                    actions.Add(CreatePickUpAction());
                }

                return actions;
            }
        }

        private Action CreatePickUpAction() 
        {
            if (Things.Count() == 1) 
            {
                var field = ToHiddenPickUpItemField(Things.Single());
                var action = new Action("get-item", "POST", Id, $"Pick up {field.Title.ToLower()}");
                action.AddField(field);
                return action;
            }
            else 
            {
                var fields = Things.Select(item => ToPickUpItemField(item)).ToList();
                var action = new Action("get-item", "POST", Id, "Pick up");
                foreach (var f in fields)
                {
                    action.AddField(f);
                }

                return action;
            }
        }

        private static Field ToPickUpItemField(Thing thing)
        {
            var field = new Field("item")
            {
                Type = "radio",
                Value = thing.Id,
                Title = thing.ToString()
            };

            return field;
        }

        private static Field ToHiddenPickUpItemField(Thing thing)
        {
            var field = new Field("item")
            {
                Type = "hidden",
                Value = thing.Id,
                Title = thing.ToString()
            };

            return field;
        }

        public virtual string Status(Player player)
        {
            var lines = new List<string>
            {
                $"Your health is {player.Health}."
            };

            if (player.IsWeak)
            {
                lines.Add("You are feeling weak.");
            }

            return string.Join(" ", lines);
        }

        public Representation Visit(Player player)
        {
            if (player == null) 
            {
                throw new RedirectException(302, "/start");
            }

            if (player.IsAlive)
            {
                return VisitAlive(player);
            }
            else
            {
                return VisitDead(player);
            }
        }

        private Representation VisitDead(Player player)
        {
            throw new RedirectException(302, "/death");
        }

        public abstract Representation VisitAlive(Player player);

        public IReadOnlyList<Thing> Things => _things;

        public IEnumerable<Monster> Monsters => _monsters.Where(it => it.IsActive);

        public void AddThing(Thing thing)
        {
            _things.Add(thing);
        }

        public void AddMonster(Monster monster)
        {
            _monsters.Add(monster);
        }

        public Representation PickUp(Player player, string thingId)
        {
            player.Keep(Take(thingId));
            return Visit(player);
        }

        private Thing Take(string thingId)
        {
            var item = _things.FirstOrDefault(it => thingId == it.Id);
            if (item == null)
            {
                throw new Exception($"No such item: {thingId}");
            }

            _things.Remove(item);

            return item;
        }
    }
}
