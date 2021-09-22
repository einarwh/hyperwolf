using System;

namespace Wolf
{
    public class FoodSupply : Thing
    {
        public override string Id => "food-supply";

        private int _rations = 0;

        public void Increment()
        {
            ++_rations;
        }

        public void Decrement()
        {
            if (_rations == 0)
            {
                throw new Exception("No food left!");
            }

            --_rations;
        }

        public bool IsEmpty => _rations <= 0;

        public override string Name => $"Food ({_rations} rations)";
    }
}
