using System.Collections.Generic;

namespace Wolf
{
    public class CastleExit : Room
    {
        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title("Castle Exit"),
                Description = new Description("..."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", "/castle-exit"),
                        new Link("player", "/player"),
                        new Link("provisions", "/provisions"),
                        //new Link("east", "/rear-vestibule")
                    }
            };
        }
    }
}
