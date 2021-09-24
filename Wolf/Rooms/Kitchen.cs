using System.Collections.Generic;

namespace Wolf
{
    public class Kitchen : RegularRoom
    {
        public override string Id => "/kitchen";

        public override string Title => "Kitchen";

        public override List<Link> NavigationLinks =>
            new List<Link>
            {
                new Link("south", "/store-room")
            };

        public override string Description(Player player)
        {
            return "This is the castle's kitchen. Through windows in the north wall you can see a secret herb garden. A door leaves the kitchen to the south.";
        }
    }
}
