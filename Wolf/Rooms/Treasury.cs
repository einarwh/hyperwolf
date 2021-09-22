using System;
using System.Collections.Generic;
using System.Linq;

namespace Wolf
{
    public class Treasury : Room
    {
        public override string Id => "/treasury";

        public override string Title => "Treasury";

        public override bool MayHoldRandomTreasure => false;

        public Treasury(Random random)
        {
            var amount = 100 + random.Next(1, 100);
            Add(new Treasure(new Money(amount)));
        }

        public override Representation VisitWhenLit(Player player)
        {
            var actions = new List<Action>();
            if (Things.Any())
            {
                var fields = Things.Select(item => ToItemField(item)).ToList();
                var action = new Action("get-item", "POST", Id, "Pick up");
                foreach (var f in fields)
                {
                    action.AddField(f);
                }

                actions.Add(action);
            }

            return new Representation
            {
                Title = new Title(Title),
                Description = new Description("This room was used as the castle treasury in by-gone years... There are no windows, just exits to the north and to the east."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", Id),
                        new Link("player", "/player"),
                        new Link("shop", "/shop"),
                        new Link("north", "/chambermaids-room"),
                        new Link("east", "/small-room")
                    },
                Actions = actions
            };
        }

        private static Field ToItemField(Thing thing)
        {
            var field = new Field("item")
            {
                Type = "radio",
                Value = thing.Id,
                Title = thing.ToString()
            };

            return field;
        }
    }
}
