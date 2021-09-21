using System.Collections.Generic;

namespace Wolf
{
    public class SmallRoom : Room
    {
        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title("Small Room"),
                Description = new Description("This is the small room outside the castle lift which can be entered by a door to the north. Another door leads to the west. You can see the lake through the southern windows."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", "/small-room"),
                        new Link("player", "/player"),
                        new Link("provisions", "/provisions"),
                        new Link("north", "/lift"),
                        new Link("east", "/treasury")
                    }
            };
        }
    }
}
