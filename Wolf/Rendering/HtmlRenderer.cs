using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Wolf
{
    public class HtmlRenderer : IRenderer
    {
        public string ContentType => "text/html";

        private static string PropertyToHtml(string name, object value)
        {
            if (typeof(IEnumerable).IsAssignableFrom(value.GetType()))
            {
                var enumerable = (IEnumerable)value;
                var listItems = new List<string>();
                foreach (var item in enumerable)
                {
                    listItems.Add($"<li>{item}</li>");
                }

                return $"<h3>{name}</h3><div><ul>{string.Join("", listItems)}</ul></div>";
            }
            else
            {
                return $"<h3>{name}</h3><p>{value}</p>";
            }
        }

        public string Render(Representation location)
        {
            var props = location.Properties.Select(it => PropertyToHtml(it.Key, it.Value));
            var s = string.Join("", props);

            var linksList = CreateLinksList(location.Links); 
            
            return $"<html><title>{location.Title}</title><body><h1>{location.Title}</h1><p>{location.Description}</p><div>{s}</div>{linksList}</body></html>";
        }

        private static Link RenameSelfLink(Link link)
        {
            return new Link("refresh", link.Value);
        }

        private static string CreateLinksList(List<Link> links)
        {
            if (links.Any())
            {
                var linkItems = links
                    .Select(it => it.Relation == "self" ? RenameSelfLink(it) : it)
                    .Select(it => $"<li>{LinkToHtml(it)}</li>");
                var s = string.Join("", linkItems);
                return  $"Navigation: <ul>{s}</ul>";
            }
            else
            {
                return "";
            }
        }

        private static string LinkToHtml(Link link)
        {
            return $"<a href=\"{link.Value}\">{link.Relation}</a>";
        }
    }
}
