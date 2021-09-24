using System.Collections.Generic;

namespace Wolf
{
    public class ChambermaidsRoom : RegularRoom
    {
        public override string Id => "/chambermaids-room";

        public override string Title => "Chambermaids' Room";

        public override List<Link> NavigationLinks =>
            new List<Link>
            {
                new Link("north", "/dressing-chamber"),
                new Link("south", "/treasury"),
                new Link("west", "/master-bedroom")
            };

        public override string Description(Player player)
        {
            return "You are in the chambermaids' room. There is an exit to the west and a door to the south.";
        }
    }
}
