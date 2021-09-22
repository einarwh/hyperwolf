using System.Collections.Generic;

namespace Wolf
{
    public class DressingChamber : Room
    {
        public override string Id => "/dressing-chamber";

        public override string Title => "Dressing Chamber";

        public override bool MayHoldRandomTreasure => true;

        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title(Title),
                Description = new Description("This tiny room on the upper level is the dressing chamber. There is a window to the north, with a view of the herb garden down below. A door leaves to the south."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", Id),
                        new Link("player", "/player"),
                        new Link("shop", "/shop"),
                        new Link("south", "/chambermaids-room")
                    }
            };
        }
    }
}
