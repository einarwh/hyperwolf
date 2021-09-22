using System.Collections.Generic;

namespace Wolf
{
    public class Dungeon : Room
    {
        public override string Id => "/dungeon";

        public override string Title => "Dungeon";

        public override bool MayHoldRandomTreasure => true;

        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title(Title),
                Description = new Description("You are in the dank, dark dungeon. There is a single exit, a small hole in the wall towards the west."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", Id),
                        new Link("player", "/player"),
                        new Link("shop", "/shop"),
                        new Link("west", "/guard-room")
                    }
            };
        }
    }
}
