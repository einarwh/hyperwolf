using System.Collections.Generic;

namespace Wolf
{
    public class Entrance : Place
    {
        public override string Id => "/entrance";

        public override string Title => "Entrance";

        public override List<Link> NavigationLinks => 
            new List<Link>
            {
                new Link("east", "/hallway")
            };

        public override string Description(Player player)
        {
            return "You are at the entrance to a forbidding-looking stone castle. You are facing east.";
        }

        public override Representation VisitAlive(Player player)
        {
            player.Location = this;

            return new Representation
            {
                Title = new Title(Title),
                Description = new Description(Description(player)),
                Status = new Status(Status(player)),
                Properties = new Dictionary<string, object>(),
                Links = Links(player)
            };
        }
    }
}
