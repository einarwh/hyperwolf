using System.Collections.Generic;

namespace Wolf
{
    public class MeetingRoom : Room
    {
        public override string Id => "/meeting-room";

        public override string Title => "Meeting Room";

        public override List<Link> NavigationLinks =>
            new List<Link>
            {
                new Link("south", "/inner-hallway")
            };
        
        public override string Description(Player player)
        {
            return "This is the monarch's meeting room. There is a single exit to the south.";
        }

        public MeetingRoom(Treasure treasure)
        {
            AddThing(treasure);
        }
    }
}
