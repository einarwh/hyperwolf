using System.Collections.Generic;

namespace Wolf
{
    public class PlayerDeath
    {
        public string Id => "/death";

        public string Title => "Game Over";

        public Representation Summary(Player player)
        {
            var properties = new Dictionary<string, object>();

            return new Representation
            {
                Title = new Title("You have died"),
                Description = new Description(player.CauseOfDeath),
                Properties = properties,
                Links = new List<Link> { new Link("play-again", "/play-again") },
                Actions = new List<Action>()
            };
        }
    }

}
