using System.Collections.Generic;

namespace Wolf
{
    public class ChambermaidsRoom : Room
    {
        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title("Chambermaids' Room"),
                Description = new Description("You are in the chambermaids' room. There is an exit to the west and a door to the south."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", "/chambermaids-room"),
                        new Link("player", "/player"),
                        new Link("provisions", "/provisions"),
                        new Link("north", "/dressing-chamber"),
                        new Link("south", "/treasury"),
                        new Link("west", "/master-bedroom")
                    }
            };
        }
    }
}
