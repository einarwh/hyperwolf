using System.Collections.Generic;

namespace Wolf
{
    public class UpperHallway : RegularRoom
    {
        public override string Id => "/upper-hallway";

        public override string Title => "Upper Hallway";

        public override List<Link> NavigationLinks =>
            new List<Link>
            {
                new Link("north", "/master-bedroom"),
                new Link("down", "/inner-hallway")
            };

        public override string Description(Player player)
        {
            return "This is the L-shaped upper hallway. To the north is a door, and there is a stairwell in the hall was well. You can see the lake through the south windows.";
        }
    }
}
