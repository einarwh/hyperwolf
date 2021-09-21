using System.Collections.Generic;

namespace Wolf
{
    public class Dungeon : Room
    {
        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title("Dungeon"),
                Description = new Description("You are in the dank, dark dungeon. There is a single exit, a small hole in the wall towards the west."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", "/dungeon"),
                        new Link("player", "/player"),
                        new Link("provisions", "/provisions"),
                        new Link("west", "/guard-room")
                    }
            };
        }
    }
}
