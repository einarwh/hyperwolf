using System.Collections.Generic;

namespace Wolf
{
    public class Action
    { 
        private readonly string _name;
        private readonly string _method;
        private readonly string _href;
        private readonly string _title;
        private readonly List<Field> _fields;

        public Action(string name, string method, string href, string title)
        {
            _name = name;
            _method = method;
            _href = href;
            _title = title;
            _fields = new List<Field>();
        }

        public string Name => _name;
        public string Method => _method;
        public string Href => _href;
        public string Title => _title;

        public void AddField(Field field) => _fields.Add(field);

        public IReadOnlyList<Field> Fields => _fields;
    }
}
