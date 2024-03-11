using Microsoft.AspNetCore.Http;
using System.Web;

namespace Wolf
{
    public class StartResource : Resource
    {
        private readonly Game _game;
        private readonly PlayerCreation _creation;

        public StartResource(Game game)
        {
            _game = game;
            _creation = new PlayerCreation();
        }

        protected override Representation Get(HttpContext context)
        {
            return _creation.Prompt();
        }

        protected override Representation Post(HttpContext context)
        {
            var form = context.Request.Form;
            var name = HttpUtility.HtmlEncode(form["name"][0]);
            _game.Player = new Player(name);
            throw new RedirectException(302, "/entrance");
        }
    }
}
