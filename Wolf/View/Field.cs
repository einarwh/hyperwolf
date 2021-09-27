namespace Wolf
{
    public class Field
    {
        private readonly string _name;

        public Field(string name)
        {
            _name = name;
        }

        public string Name => _name;

        public string Type { get; set; }

        public string Title { get; set; }

        public string Value { get; set; }
    }
}
