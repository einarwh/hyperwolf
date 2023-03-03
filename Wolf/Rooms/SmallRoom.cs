using System.Collections.Generic;

namespace Wolf
{
    public class SmallRoom : RegularRoom
    {
        public override string Id => "/small-room";

        public override string Title => "Small Room";

        public override List<Link> NavigationLinks =>
            new List<Link>
            {
                new Link("north", "/lift"),
                new Link("west", "/treasury")
            };

        public override string Description(Player player)
        {
            return "This is the small room outside the castle lift which can be entered by a door to the north. Another door leads to the west. You can see the lake through the southern windows.";
        }
    }
}
