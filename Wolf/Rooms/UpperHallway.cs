using System.Collections.Generic;

namespace Wolf
{
    public class UpperHallway : Room
    {
        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title("Upper Hallway"),
                Description = new Description("This is the L-shaped upper hallway. To the north is a door, and there is a stairwell in the hall was well. You can see the lake through the south windows."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", "/upper-hallway"),
                        new Link("player", "/player"),
                        new Link("provisions", "/provisions"),
                        new Link("north", "/master-bedroom"),
                        new Link("down", "/inner-hallway")
                    }
            };
        }
    }
}
