using System.Collections.Generic;

namespace Wolf
{
    public class StoreRoom : RegularRoom
    {
        public override string Id => "/store-room";

        public override string Title => "Store Room";

        public override List<Link> NavigationLinks =>
            new List<Link>
            {
                new Link("north", "/kitchen"),
                new Link("south", "/rear-vestibule")
            };

        public override string Description(Player player)
        {
            return "You are in the store room, amidst spices, vegetables, and vast sacks of flour and other provisions. There is a door to the north and one to the south.";
        }
    }
}
