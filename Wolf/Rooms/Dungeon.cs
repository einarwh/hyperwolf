using System.Collections.Generic;

namespace Wolf
{
    public class Dungeon : RegularRoom
    {
        public override string Id => "/dungeon";

        public override string Title => "Dungeon";

        public override List<Link> NavigationLinks =>
            new List<Link>
            {
                new Link("west", "/guard-room")
            };

        public override string Description(Player player)
        {
            return "You are in the dank, dark dungeon. There is a single exit, a small hole in the wall towards the west.";
        }
    }
}
