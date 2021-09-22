using System.Collections.Generic;

namespace Wolf
{
    public class Hallway : Room
    {
        public override string Id => "/hallway";

        public override string Title => "The Hallway";

        public override bool MayHoldRandomTreasure => true;

        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title(Title),
                Description = new Description("You are in the hallway. There is a door to the south. Through windows to the north you can see a secret herb garden."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", Id),
                        new Link("player", "/player"),
                        new Link("shop", "/shop"),
                        new Link("south", "/audience-chamber")
                    }
            };
        }
    }
}
