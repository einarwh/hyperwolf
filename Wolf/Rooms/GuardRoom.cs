using System.Collections.Generic;

namespace Wolf
{
    public class GuardRoom : RegularRoom
    {
        public override string Id => "/guard-room";

        public override string Title => "Guard Room";

        public override List<Link> NavigationLinks =>
            new List<Link>
            {
                new Link("east", "/dungeon"),
                new Link("up", "/inner-hallway")
            };

        public override string Description(Player player)
        {
            return "You are in the prison guardroom, in the basement of the castle. The stairwell ends in this room. There is one other exit, a small hole in the east wall.";
        }
    }
}
