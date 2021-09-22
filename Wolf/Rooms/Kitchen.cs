using System.Collections.Generic;

namespace Wolf
{
    public class Kitchen : Room
    {
        public override string Id => "/kitchen";

        public override string Title => "Kitchen";

        public override bool MayHoldRandomTreasure => true;

        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title(Title),
                Description = new Description("This is the castle's kitchen. Through windows in the north wall you can see a secret herb garden. A door leaves the kitchen to the south."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", Id),
                        new Link("player", "/player"),
                        new Link("shop", "/shop"),
                        new Link("south", "/store-room")
                    }
            };
        }
    }
}
