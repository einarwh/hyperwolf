using System.Collections.Generic;

namespace Wolf
{
    public class SmallRoom : Room
    {
        public override string Id => "/small-room";

        public override string Title => "Small Room";

        public override bool MayHoldRandomTreasure => true;

        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title(Title),
                Description = new Description("This is the small room outside the castle lift which can be entered by a door to the north. Another door leads to the west. You can see the lake through the southern windows."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", Id),
                        new Link("player", "/player"),
                        new Link("shop", "/shop"),
                        new Link("north", "/lift"),
                        new Link("east", "/treasury")
                    }
            };
        }
    }
}
