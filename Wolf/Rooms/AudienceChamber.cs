using System.Collections.Generic;

namespace Wolf
{
    public class AudienceChamber : Room
    {
        public override string Id => "/audience-chamber";

        public override string Title => "The Audience Chamber";

        public override bool MayHoldRandomTreasure => true;

        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title(Title),
                Description = new Description("This is the audience chamber. There is a window to the west. By looking to the right through it you can see the entrance to the castle. Doors leave this room to the north, east and south."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", Id),
                        new Link("player", "/player"),
                        new Link("shop", "/shop"),
                        new Link("north", "/hallway"),
                        new Link("south", "/great-hall"),
                        new Link("east", "/great-hall"),
                    }
            };
        }
    }
}
