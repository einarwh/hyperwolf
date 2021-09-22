using System.Collections.Generic;

namespace Wolf
{
    public class CastleExit : Room
    {
        public override string Id => "/castle-exit";

        public override string Title => "Castle Exit";

        public override bool MayHoldRandomTreasure => false;

        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title(Title),
                Description = new Description("..."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", Id),
                        new Link("player", "/player"),
                        new Link("shop", "/shop"),
                        //new Link("east", "/rear-vestibule")
                    }
            };
        }
    }
}
