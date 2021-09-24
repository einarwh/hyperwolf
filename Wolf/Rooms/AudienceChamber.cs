using System.Collections.Generic;

namespace Wolf
{
    public class AudienceChamber : RegularRoom
    {
        public override string Id => "/audience-chamber";

        public override string Title => "The Audience Chamber";

        public override List<Link> NavigationLinks =>
            new List<Link>
            {
                new Link("north", "/hallway"),
                new Link("south", "/great-hall"),
                new Link("east", "/great-hall"),
            };

        public override string Description(Player _) 
            => "This is the audience chamber. There is a window to the west. By looking to the right through it you can see the entrance to the castle. Doors leave this room to the north, east and south.";
    }
}
