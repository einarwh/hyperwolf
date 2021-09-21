using System.Collections.Generic;

namespace Wolf
{
    public class DressingChamber : Room
    {
        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title("Dressing Chamber"),
                Description = new Description("This tiny room on the upper level is the dressing chamber. There is a window to the north, with a view of the herb garden down below. A door leaves to the south."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", "/dressing-chamber"),
                        new Link("player", "/player"),
                        new Link("provisions", "/provisions"),
                        new Link("south", "/chambermaids-room")
                    }
            };
        }
    }
}
