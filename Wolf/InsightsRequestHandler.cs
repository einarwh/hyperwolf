using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Wolf
{
    public class InsightsRequestHandler
    {
        private readonly MainRequestHandler _main;

        public InsightsRequestHandler(MainRequestHandler main) {
            _main = main;
        }

        private static string GetGameListItem(GameRequestHandler grh) {
            var player = grh.Game.Player;
            var status = player.IsAlive ? (player.HasWon ? "won" : "alive") : "dead";
            var maybeLocation = player.Location == null ? "" : $" at {player.Location.Title}";
            var idleSeconds = (int) (DateTime.UtcNow - grh.LastRequestTime).TotalSeconds;
            return $"<li>Game: {grh.Game.GameId}<br/>Player: {grh.Game.Player.Name} ({status}){maybeLocation}<br/>Started: {grh.CreatedTime}<br/>Last active: {grh.LastRequestTime}<br/>Idle time: {idleSeconds} seconds</li>";
        }

        private static string GetSummaryString(List<GameRequestHandler> games) {
            if (games.Count() == 1) {
                return "There is 1 active game.";
            }
            else {
                return $"There are {games.Count()} active games.";
            }
        }

        public string Render()
        {
            var title = "Insights";
            var games = _main.Games.Select(it => it.Value).ToList();
            var summary = $"<p>{GetSummaryString(games)}</p>";
            var listItems = games.Select(it => GetGameListItem(it)).ToList();
            var listContent = string.Join("\n", listItems);
            var list = listItems.Any() ? $"<ul>{listContent}</ul>" : "";
            var metaTags = new [] {
                "<meta charset=\"UTF-8\">",
                "<meta name=\"description\" content=\"Hypermedia adventure game\">",
                "<meta name=\"author\" content=\"Einar W. Høst\">",
                "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">"
            };
            var metaString = string.Join("\n", metaTags);
            return $"<!DOCTYPE html><html><head>{metaString}<title>{title}</title><body><h1>{title}</h1>{summary}{list}</body></html>";
        }

        public async Task Handle(HttpContext context) 
        {
            context.Response.StatusCode = 200;
            var s = Render();
            context.Response.Headers.Add("content-type", "text/html");
            await context.Response.WriteAsync(s);
        }
    }
}
