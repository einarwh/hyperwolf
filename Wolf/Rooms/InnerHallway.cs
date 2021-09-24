using System.Collections.Generic;

namespace Wolf
{
    public class InnerHallway : RegularRoom
    {
        public override string Id => "/inner-hallway";

        public override string Title => "Inner Hallway";

        public override List<Link> NavigationLinks =>
            new List<Link>
            {
                new Link("north", "/meeting-room"),
                new Link("west", "/great-hall"),
                new Link("up", "/upper-hallway"),
                new Link("down", "/guard-room"),
            };

        public override string Description(Player player)
        {
            return "This inner hallway contains a door to the north, and one to the west, and a circular stairwell passes through the room. You can see an ornamental lake through the windows to the south.";
        }
    }

}
