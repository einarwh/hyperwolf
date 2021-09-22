namespace Wolf
{
    public class Money
    {
        private readonly int _amount;

        public Money(int amount)
        {
            _amount = amount;
        }

        public int ToInt()
        {
            return _amount;
        }

        public static Money operator +(Money a, Money b)
            => new Money(a._amount + b._amount);

        public static Money operator -(Money a, Money b)
            => new Money(a._amount - b._amount);

        public static bool operator >(Money a, Money b)
            => a._amount > b._amount;

        public static bool operator <(Money a, Money b)
            => a._amount < b._amount;


        public override string ToString()
        {
            return $"${_amount}";
        }
    }
}
