using System.Collections.Generic;

namespace Wolf
{
    public class StoreRoom : Room
    {
        public override string Id => "/store-room";

        public override string Title => "Store Room";

        public override bool MayHoldRandomTreasure => true;

        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title(Title),
                Description = new Description("You are in the store room, amidst spices, vegetables, and vast sacks of flour and other provisions. There is a door to the north and one to the south."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", Id),
                        new Link("player", "/player"),
                        new Link("shop", "/shop"),
                        new Link("north", "/kitchen"),
                        new Link("south", "/rear-vestibule")
                    }
            };
        }
    }
}
