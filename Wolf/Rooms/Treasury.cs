using System;
using System.Collections.Generic;

namespace Wolf
{
    public class Treasury : Room
    {
        public override string Id => "/treasury";

        public override string Title => "Treasury";

        public override List<Link> NavigationLinks =>
            new List<Link>
            {
                new Link("north", "/chambermaids-room"),
                new Link("east", "/small-room")
            };

        public Treasury(Treasure treasure)
        {
            AddThing(treasure);
        }

        public override string Description(Player player)
        {
            return "This room was used as the castle treasury in by-gone years... There are no windows, just exits to the north and to the east.";
        }
    }
}
