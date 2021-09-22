using System.Collections.Generic;

namespace Wolf
{
    public class Lift : Room
    {
        public override string Id => "/lift";

        public override string Title => "Lift";

        public override bool MayHoldRandomTreasure => false;

        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title(Title),
                Description = new Description("You have entered the lift... It slowly descends..."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", Id),
                        new Link("player", "/player"),
                        new Link("shop", "/shop")
                    }
            };
        }
    }
}
