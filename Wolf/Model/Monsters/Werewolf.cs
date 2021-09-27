using System;

namespace Wolf
{
    public class Werewolf : Monster
    {
        public override string Id => "/werewolf";

        public override string Title => "Ferocious Werewolf";

        public override int DangerLevel { get; set; } = 5;

        public Werewolf(Random random) : base(random) { }
    }
}
