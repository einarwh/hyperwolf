using System.Collections.Generic;

namespace Wolf
{
    public class RearVestibule : Room
    {
        public override string Id => "/rear-vestibule";

        public override string Title => "Rear Vestibule";

        public override bool MayHoldRandomTreasure => true;

        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title(Title),
                Description = new Description("You are in the rear vestibule. There are windows to the south from which you can see the ornamental lake. There is an exit to the east, and one to the north."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", Id),
                        new Link("player", "/player"),
                        new Link("shop", "/shop"),
                        new Link("north", "/store-room"),
                        new Link("east", "/castle-exit")
                    }
            };
        }
    }
}
