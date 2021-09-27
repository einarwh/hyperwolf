using System;

namespace Wolf
{
    public class Dragon : Monster
    {
        public override string Id => "/dragon";

        public override string Title => "Devastating Ice-Dragon";

        public override int DangerLevel { get; set; } = 20;

        public Dragon(Random random) : base(random) {}
    }
}
