using System.Collections.Generic;

namespace Wolf
{
    public class ChambermaidsRoom : Room
    {
        public override string Id => "/chambermaids-room";

        public override string Title => "Chambermaids' Room";

        public override bool MayHoldRandomTreasure => true;

        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title(Title),
                Description = new Description("You are in the chambermaids' room. There is an exit to the west and a door to the south."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", Id),
                        new Link("player", "/player"),
                        new Link("shop", "/shop"),
                        new Link("north", "/dressing-chamber"),
                        new Link("south", "/treasury"),
                        new Link("west", "/master-bedroom")
                    }
            };
        }
    }
}
