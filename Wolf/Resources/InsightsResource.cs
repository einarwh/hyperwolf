using Microsoft.AspNetCore.Http;
using System;
using System.Web;

namespace Wolf
{
    public class InsightsResource : Resource
    {
        private readonly PlayerCreation _creation;
        private readonly MainRequestHandler _gameRegistry;

        private readonly Random _random;

        public InsightsResource(MainRequestHandler gameRegistry)
        {
            _creation = new PlayerCreation();
            _gameRegistry = gameRegistry;
            _random = new Random();
        }

        protected override Representation Get(HttpContext context)
        {
            return _creation.Prompt();
        }

        protected override Representation Post(HttpContext context)
        {
            var form = context.Request.Form;
            var name = HttpUtility.HtmlEncode(form["name"][0]);
            var player = new Player(name);
            var game = new Game(player, _random);
            _gameRegistry.AddGame(game);
            throw new RedirectException(302, $"/{game.GameId}/entrance");
        }
    }
}
