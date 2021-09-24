using System.Collections.Generic;

namespace Wolf
{
    public class RearVestibule : RegularRoom
    {
        public override string Id => "/rear-vestibule";

        public override string Title => "Rear Vestibule";

        public override List<Link> NavigationLinks =>
            new List<Link>
            {
                new Link("north", "/store-room"),
                new Link("east", "/castle-exit")
            };

        public override string Description(Player player)
        {
            return "You are in the rear vestibule. There are windows to the south from which you can see the ornamental lake. There is an exit to the east, and one to the north.";
        }
    }
}
