using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Wolf
{
    public class SirenRenderer : IRenderer
    {
        public string ContentType => "application/vnd.siren+json";

        private static Dictionary<string, object> ToSirenLink(Link link)
        {
            return new Dictionary<string, object>
            {
                ["rel"] = link.Relation,
                ["href"] = link.Value
            };
        }

        public string Render(Representation location)
        {
            var sirenLinks = location.Links.Select(ToSirenLink);

            var props = location.Properties;
            props.Add("title", location.Title.ToString());

            var dict = new Dictionary<string, object>
            {
                ["properties"] = props,
                ["links"] = sirenLinks
            };
            var s = JsonSerializer.Serialize(dict);
            return s;
        }
    }
}
