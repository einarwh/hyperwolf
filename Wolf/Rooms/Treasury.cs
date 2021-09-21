using System.Collections.Generic;

namespace Wolf
{
    public class Treasury : Room
    {
        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title("Treasury"),
                Description = new Description("This room was used as the castle treasury in by-gone years... There are no windows, just exits to the north and to the east."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", "/treasury"),
                        new Link("player", "/player"),
                        new Link("provisions", "/provisions"),
                        new Link("north", "/chambermaids-room"),
                        new Link("east", "/small-room")
                    }
            };
        }
    }
}
