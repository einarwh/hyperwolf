﻿using System.Collections.Generic;

namespace Wolf
{
    public class GreatHall : Room
    {
        public override string Id => "/great-hall";
        
        public override string Title => "The Great Hall";

        public override bool MayHoldRandomTreasure => true;

        public override Representation VisitWhenLit(Player player)
        {
            return new Representation
            {
                Title = new Title(Title),
                Description = new Description("You are in the great hall, an L-shaped room. There are doors to the east and to the north in the alcove is a door to the west."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", Id),
                        new Link("player", "/player"),
                        new Link("shop", "/shop"),
                        new Link("north", "/audience-chamber"),
                        new Link("east", "/inner-hallway"),
                        new Link("west", "/audience-chamber"),
                    }
            };
        }
    }
}
