using System.Collections.Generic;

namespace Wolf
{
    public class MasterBedroom : Room
    {
        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title("Master Bedroom"),
                Description = new Description("You are in the master bedroom on the upper level of the castle... Looking down from the window to the west you can see the entrance to the castle, while the secret herb garden is visible below the north window. There are doors to the east and to the south."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", "/master-bedroom"),
                        new Link("player", "/player"),
                        new Link("provisions", "/provisions"),
                        new Link("south", "/upper-hallway"),
                        new Link("east", "/chambermaids-room")
                    }
            };
        }   
    }
}
