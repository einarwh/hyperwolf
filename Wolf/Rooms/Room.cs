using System.Collections.Generic;

namespace Wolf
{
    public abstract class Room : Place
    {
        public abstract bool MayHoldRandomTreasure { get; }

        public override Representation Visit(Player player)
        {
            player.Location = this; 
            if (player.HasLight)
            {
                return VisitWhenLit(player);
            }
            else
            {
                return VisitWhenDark(player);
            }
        }


        public abstract Representation VisitWhenLit(Player player);

        public Representation VisitWhenDark(Player player)
        {
            return new Representation
            {
                Title = new Title("Somewhere"),
                Description = new Description("It is too dark to see anything."),
                Properties = new Dictionary<string, object>(),
                Links = new List<Link>
                    {
                        new Link("self", Id),
                        new Link("player", "/player"),
                        new Link("shop", "/shop")
                    }
            };

        }
    }
}
