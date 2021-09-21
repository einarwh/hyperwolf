using System.Collections.Generic;

namespace Wolf
{
    public class AudienceChamber : Room
    {
        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title("The Audience Chamber"),
                Description = new Description("This is the audience chamber. There is a window to the west. By looking to the right through it you can see the entrance to the castle. Doors leave this room to the north, east and south."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", "/audience-chamber"),
                        new Link("player", "/player"),
                        new Link("provisions", "/provisions"),
                        new Link("north", "/hallway"),
                        new Link("south", "/great-hall"),
                        new Link("east", "/great-hall"),
                    }
            };
        }
    }
}
