using System.Collections.Generic;

namespace Wolf
{
    public class MasterBedroom : RegularRoom
    {
        public override string Id => "/master-bedroom";

        public override string Title => "Master Bedroom";

        public override List<Link> NavigationLinks =>
            new List<Link>
            {
                new Link("south", "/upper-hallway"),
                new Link("east", "/chambermaids-room")
            };

        public override string Description(Player player)
        {
            return "You are in the master bedroom on the upper level of the castle... Looking down from the window to the west you can see the entrance to the castle, while the secret herb garden is visible below the north window. There are doors to the east and to the south.";
        }
    }
}
