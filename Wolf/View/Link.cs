namespace Wolf
{
    public class Link
    {
        public Link(string relation, string value)
        {
            Relation = relation;
            Value = value;
        }

        public string Relation { get; }

        public string Value { get; }
    }
}
