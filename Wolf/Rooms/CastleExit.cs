using System.Collections.Generic;

namespace Wolf
{
    public class CastleExit : Room
    {
        public override string Id => "/castle-exit";

        public override string Title => "Castle Exit";

        public override List<Link> NavigationLinks =>
            new List<Link>()
            {
                new Link("play-again", "/play-again")
            };

        public override List<Link> Links(Player player)
        {
            return NavigationLinks;
        }

        public override string Description(Player player)
        {
            player.Win();
            return $"You've done it!! That was the exit from the castle. You have succeeded, {player.Name}! You managed to get out of the castle alive! Well done! ";
        }

        public override string Status(Player player)
        {
            int score = 5 * player.Health.ToInt() + 2 * player.Wealth.ToInt();
            return $"Your score is {score}.";
        }
    }
}
