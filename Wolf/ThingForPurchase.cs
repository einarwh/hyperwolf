namespace Wolf
{
    public class ThingForPurchase
    {
        private readonly Thing _thing;
        private readonly Money _price;

        public ThingForPurchase(Thing thing, Money price)
        {
            _thing = thing;
            _price = price;
        }

        public Thing Thing => _thing;

        public Money Price => _price;

        public override string ToString()
        {
            return $"{_thing} ({_price})";
        }
    }

}
