using System;

namespace Wolf
{
    public class Fleshgorger : Monster
    {
        public override string Id => "/fleshgorger";

        public override string Title => "Fanatical Fleshgorger";

        public override int DangerLevel { get; set; } = 10;

        public Fleshgorger(Random random) : base(random) { }
    }
}
