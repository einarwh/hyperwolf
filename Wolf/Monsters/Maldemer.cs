using System;

namespace Wolf
{
    public class Maldemer : Monster
    {
        public override string Id => "/maldemer";

        public override string Title => "Malovent Maldemer";

        public override int DangerLevel { get; set; } = 15;

        public Maldemer(Random random) : base(random) { }
    }
}
