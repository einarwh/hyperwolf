using System.Collections.Generic;

namespace Wolf
{
    public class Representation
    {
        public List<Link> Links { get; set; }

        public List<Action> Actions { get; set; }

        public Title Title { get; set; }

        public Description Description { get; set; }

        public Status Status { get; set; }

        public Dictionary<string, object> Properties { get; set; }
    }
}
