using System.Collections.Generic;

namespace Wolf
{
    public class RearVestibule : Room
    {
        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title("Rear Vestibule"),
                Description = new Description("You are in the rear vestibule. There are windows to the south from which you can see the ornamental lake. There is an exit to the east, and one to the north."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", "/rear-vestibule"),
                        new Link("player", "/player"),
                        new Link("provisions", "/provisions"),
                        new Link("north", "/store-room"),
                        new Link("east", "/castle-exit")
                    }
            };
        }
    }
}
