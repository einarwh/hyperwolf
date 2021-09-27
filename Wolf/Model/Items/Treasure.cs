namespace Wolf
{
    public class Treasure : Thing
    {
        public override string Id => "treasure";

        public override string Name => "Treasure";

        private readonly Money _worth;

        public Treasure(Money worth)
        {
            _worth = worth;
        }

        public Money Worth => _worth;

        public override string ToString()
        {
            return $"{Name} ({Worth})";
        }
    }
}
