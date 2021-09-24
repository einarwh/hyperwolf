using System.Collections.Generic;

namespace Wolf
{
    public class DressingChamber : RegularRoom
    {
        public override string Id => "/dressing-chamber";

        public override string Title => "Dressing Chamber";

        public override List<Link> NavigationLinks =>
            new List<Link>
            {
                new Link("south", "/chambermaids-room")
            };

        public override string Description(Player player)
        {
            return "This tiny room on the upper level is the dressing chamber. There is a window to the north, with a view of the herb garden down below. A door leaves to the south.";
        }
    }
}
