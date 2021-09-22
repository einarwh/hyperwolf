using System.Collections.Generic;

namespace Wolf
{
    public class GuardRoom : Room
    {
        public override string Id => "/guard-room";

        public override string Title => "Guard Room";

        public override bool MayHoldRandomTreasure => true;

        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title(Title),
                Description = new Description("You are in the prison guardroom, in the basement of the castle. The stairwell ends in this room. There is one other exit, a small hole in the east wall."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", Id),
                        new Link("player", "/player"),
                        new Link("shop", "/shop"),
                        new Link("east", "/dungeon"),
                        new Link("up", "/inner-hallway")
                    }
            };
        }
    }
}
