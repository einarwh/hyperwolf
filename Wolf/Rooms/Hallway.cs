using System.Collections.Generic;

namespace Wolf
{
    public class Hallway : RegularRoom
    {
        public override string Id => "/hallway";

        public override string Title => "The Hallway";

        public override List<Link> NavigationLinks =>
            new List<Link>
            {
                new Link("south", "/audience-chamber")
            };

        public override string Description(Player player)
        {
            return "You are in the hallway. There is a door to the south. Through windows to the north you can see a secret herb garden.";
        }
    }
}
