using System.Collections.Generic;

namespace Wolf
{
    public class Kitchen : Room
    {
        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title("Kitchen"),
                Description = new Description("This is the castle's kitchen. Through windows in the north wall you can see a secret herb garden. A door leaves the kitchen to the south."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", "/kitchen"),
                        new Link("player", "/player"),
                        new Link("provisions", "/provisions"),
                        new Link("south", "/store-room")
                    }
            };
        }
    }
}
