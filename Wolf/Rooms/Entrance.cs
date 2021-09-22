using System.Collections.Generic;

namespace Wolf
{
    public class Entrance : Place
    {
        public override string Id => "/entrance";

        public override string Title => "Entrance";

        public override Representation Visit(Player player)
        {
            player.Location = this;

            return new Representation
            {
                Title = new Title(Title),
                Description = new Description("You are at the entrance to a forbidding-looking stone castle. You are facing east."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", Id),
                        new Link("player", "/player"),
                        new Link("shop", "/shop"),
                        new Link("east", "/hallway")
                    }
            };
        }
    }
}
