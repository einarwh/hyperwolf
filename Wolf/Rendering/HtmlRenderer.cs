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
            if (!(value is string) && typeof(IEnumerable).IsAssignableFrom(value.GetType()))
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
            var actionForm = CreateActionForm(location.Actions);
            var metaTags = new [] {
                "<meta charset=\"UTF-8\">",
                "<meta name=\"description\" content=\"Hypermedia adventure game\">",
                "<meta name=\"author\" content=\"Einar W. Høst\">",
                "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">"
            };
            var metaString = string.Join("\n", metaTags);
            return $"<!DOCTYPE html><html><head>{metaString}<title>{location.Title}</title></head><body><h1>{location.Title}</h1><p>{location.Description}</p><p>{location.Status}</p><div>{s}</div>{linksList}{actionForm}</body></html>";
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
                    .Select(it => $"<li>{LinkToAnchorTag(it)}</li>");
                var s = string.Join("", linkItems);
                return  $"<h3>Navigation</h3> <ul>{s}</ul>";
            }
            else
            {
                return "";
            }
        }

        private static string LinkToAnchorTag(Link link)
        {
            return $"<a href=\"{link.Value}\">{link.Relation}</a>";
        }

        private static string CreateActionForm(List<Action> actions)
        {
            if (actions != null && actions.Any())
            {
                var forms = actions.Select(ActionToForm);
                var s = string.Join("\n", forms);
                return $"<h3>Actions</h3>{s}";
            }
            else
            {
                return "";
            }
        }

        private static string FieldToInput(Field field)
        {
            var properties = new List<string>();
            properties.Add($"id=\"{field.Name}\"");
            properties.Add($"name=\"{field.Name}\"");

            if (field.Type != null)
            {
                properties.Add($"type=\"{field.Type}\"");
            }

            if (field.Value != null)
            {
                properties.Add($"value=\"{field.Value}\"");
            }

            var s = string.Join(" ", properties);

            if (field.Type == "hidden") 
            {
                return $"<input {s} />";
            }
            else 
            {
                var label = field.Title ?? field.Name;

                return $"<input {s} /><label for=\"{field.Name}\">{label}</label>";
            }
        }

        private static string ActionToForm(Action action) 
        {
            var inputs = action.Fields.Select(f => FieldToInput(f));
            var inputsStr = string.Join("<br/>", inputs);
            var submitStr = $"<input type=\"submit\" value=\"{action.Title}\">";
            return $"<form method=\"{action.Method}\" action=\"{action.Href}\">{inputsStr}<br/>{submitStr}</form>";
        }
    }
}
