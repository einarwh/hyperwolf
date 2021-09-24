using System.Collections.Generic;
using System.Linq;

namespace Wolf
{
    public abstract class Room : Place
    {
        public override Representation VisitAlive(Player player)
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

        public Representation VisitWhenDark(Player _)
        {
            return new Representation
            {
                Title = new Title("Somewhere"),
                Description = new Description("It is too dark to see anything."),
                Properties = new Dictionary<string, object>(),
                Links = GenericLinks
            };
        }

        public Representation VisitWhenLit(Player player)
        {
            var props = new Dictionary<string, object>();
            if (Monsters.Any(it => it.IsAlive))
            {
                var monster = Monsters.First(it => it.IsAlive);
                props.Add("encounter", $"There is a {monster.Title} here!");
            }

            return new Representation
            {
                Title = new Title(Title),
                Description = new Description(Description(player)),
                Status = new Status(Status(player)),
                Properties = props,
                Links = Links(player),
                Actions = Actions(player)
            };
        }
    }
}
