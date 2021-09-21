using System.Collections.Generic;

namespace Wolf
{
    public class Entrance : Room
    {
        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title("Entrance"),
                Description = new Description("You are at the entrance to a forbidding-looking stone castle. You are facing east."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", "/entrance"),
                        new Link("player", "/player"),
                        new Link("provisions", "/provisions"),
                        new Link("east", "/hallway")
                    }
            };
        }
    }
}
