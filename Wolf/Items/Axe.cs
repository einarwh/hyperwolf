namespace Wolf
{
    public class Axe : Weapon
    {
        public override string Id => "axe";

        public override string Name => "Axe";

        public override double Factor => 0.80;

        public override string ToString()
        {
            return Name;
        }
    }
}
