using System.Collections.Generic;

namespace Wolf
{
    public class Lift : Room
    {
        public override string Id => "/lift";

        public override string Title => "Lift";

        public override List<Link> GenericLinks => new List<Link>();

        public override List<Link> NavigationLinks =>
            new List<Link>
            {
                new Link("continue", "/rear-vestibule")
            };

        public override string Description(Player player)
        {
            return "You have entered the lift... It slowly descends...";
        }
    }
}
