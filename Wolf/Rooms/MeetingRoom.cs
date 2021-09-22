using System.Collections.Generic;

namespace Wolf
{
    public class MeetingRoom : Room
    {
        public override string Id => "/meeting-room";

        public override string Title => "Meeting Room";

        public override bool MayHoldRandomTreasure => true;

        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title(Title),
                Description = new Description("The is the monarch's private meeting room. There is a single exit to the south."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", Id),
                        new Link("player", "/player"),
                        new Link("shop", "/shop"),
                        new Link("south", "/inner-hallway")
                    }
            };
        }
    }
}
