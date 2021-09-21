using System.Collections.Generic;

namespace Wolf
{
    public class Hallway : Room
    {
        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title("The Hallway"),
                Description = new Description("You are in the hallway. There is a door to the south. Through windows to the north you can see a secret herb garden."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", "/hallway"),
                        new Link("player", "/player"),
                        new Link("provisions", "/provisions"),
                        new Link("south", "/audience-chamber")
                    }
            };
        }
    }
}
