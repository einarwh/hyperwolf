using System.Collections.Generic;

namespace Wolf
{
    public class PlayerCreation
    {
        public string Id => "/start";

        public string Title => "Werewolves & Wanderer";

        public Representation Prompt()
        {
            var action = new Action("create-player", "POST", "/start", "Start");
            action.AddField(new Field("name")
            {
                Type = "input",
                Title = "What is your name, explorer?"
            });

            var properties = new Dictionary<string, object>();

            return new Representation
            {
                Title = new Title("Werewolves & Wanderer"),
                Description = new Description("This is a hypermedia adaptation of the game \"Werewolves and Wanderer\" from the book \"Creating Adventure Games On Your Computer\" by Tim Hartnell."),
                Properties = properties,
                Links = new List<Link>(),
                Actions = new List<Action>
                {
                    action
                }
            };
        }
    }
}
