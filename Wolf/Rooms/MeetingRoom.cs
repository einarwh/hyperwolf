using System.Collections.Generic;

namespace Wolf
{
    public class MeetingRoom : Room
    {
        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title("Meeting Room"),
                Description = new Description("The is the monarch's private meeting room. There is a single exit to the south."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", "/meeting-room"),
                        new Link("player", "/player"),
                        new Link("provisions", "/provisions"),
                        new Link("south", "/inner-hallway")
                    }
            };
        }
    }
}
