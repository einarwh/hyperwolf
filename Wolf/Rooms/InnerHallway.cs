using System.Collections.Generic;

namespace Wolf
{
    public class InnerHallway : Room
    {
        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title("Inner Hallway"),
                Description = new Description("This inner hallway contains a door to the north, and one to the west, and a circular stairwell passes through the room. You can see an ornamental lake through the windows to the south."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", "/inner-hallway"),
                        new Link("player", "/player"),
                        new Link("provisions", "/provisions"),
                        new Link("north", "/meeting-room"),
                        new Link("west", "/great-hall"),
                        new Link("up", "/upper-hallway"),
                        new Link("down", "/guard-room"),
                    }
            };
        }
    }

}
