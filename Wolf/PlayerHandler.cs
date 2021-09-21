using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Wolf
{
    public class PlayerHandler
    {
        private int _visits = 0;
        private readonly Game _game;

        public PlayerHandler(Game game)
        {
            _game = game;
        }

        private static IRenderer ChooseRenderer(string value)
        {
            var ss = value.Split(",");
            return new SirenRenderer();
        }

        public async Task Handle(HttpContext context)
        {
            ++_visits;
            var content = $"You've been here {_visits} time(s).";
            context.Response.StatusCode = 200;
            var player = _game.Player;
            var location = player.Introspect();
            var accept = context.Request.Headers["Accept"];
            var renderer = ChooseRenderer(accept[0]);
            var s = renderer.Render(location);
            context.Response.Headers.Add("content-type", renderer.ContentType);
            await context.Response.WriteAsync(s);
        }
    }
}
