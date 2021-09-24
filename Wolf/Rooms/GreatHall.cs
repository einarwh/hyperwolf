using System.Collections.Generic;

namespace Wolf
{
    public class GreatHall : RegularRoom
    {
        public override string Id => "/great-hall";
        
        public override string Title => "The Great Hall";

        public override List<Link> NavigationLinks =>
            new List<Link>
            {
                new Link("north", "/audience-chamber"),
                new Link("east", "/inner-hallway"),
                new Link("west", "/audience-chamber"),
            };

        public override string Description(Player player)
        {
            return "You are in the great hall, an L-shaped room. There are doors to the east and to the north in the alcove is a door to the west.";
        }
    }
}
