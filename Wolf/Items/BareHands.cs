namespace Wolf
{
    public class BareHands : Weapon
    {
        public override string Id => "hands";

        public override string Name => "Your bare hands";

        public override double Factor => 1.2;

        public override string ToString()
        {
            return Name;
        }
    }

}
