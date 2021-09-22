namespace Wolf
{
    public class Health
    {
        private readonly int _amount;

        public Health(int amount)
        {
            _amount = amount;
        }

        public int ToInt()
        {
            return _amount;
        }

        public static Health operator +(Health a, Health b)
            => new Health(a._amount + b._amount);

        public static Health operator -(Health a, Health b)
            => new Health(a._amount - b._amount);

        public override string ToString()
        {
            return $"{_amount} HP";
        }

    }
}
