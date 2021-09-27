namespace Wolf
{
    public abstract class Thing
    {
        public abstract string Id { get; }

        public abstract string Name { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
