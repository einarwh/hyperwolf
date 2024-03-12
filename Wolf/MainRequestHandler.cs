using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Wolf
{
    public class MainRequestHandler
    {
        private readonly Dictionary<string, GameRequestHandler> _games = new Dictionary<string, GameRequestHandler>();

        private const int MaxNumberOfConcurrentGames = 25;

        public IReadOnlyDictionary<string, GameRequestHandler> Games => _games;

        public void AddGame(Game game) 
        {
            if (_games.Values.Count() < MaxNumberOfConcurrentGames) 
            {
                _games[game.GameId] = new GameRequestHandler(game);
            }
            else 
            {
                throw new RedirectException(302, "/start");
            }
        }

        public void Tick()
        {
            var gameIds = _games.Keys;
            foreach (var id in gameIds) 
            {
                var grh = _games[id];
                var idleTime = DateTime.UtcNow - grh.LastRequestTime;
                if (idleTime.TotalMinutes > 15) 
                {
                    _games.Remove(id);
                }
                else 
                {
                    grh.Game.AdvanceTime();
                }
            }
        }

        private static IRenderer ChooseRenderer(string value)
        {
            return new HtmlRenderer();
        }

        public Task ToStart(HttpContext context)
        {
            context.Response.StatusCode = 307;
            context.Response.Headers.Add("location", "/start");
            return Task.CompletedTask;
        }

        public async Task Start(HttpContext context)
        {
            var resource = new StartResource(this);
            await HandleResource(context, resource, null);
        }

        public async Task HandleResource(HttpContext context, Resource resource, string linkPrefix) 
        {
            if (resource != null)
            {
                try
                {
                    var location = resource.Request(context);
                    if (linkPrefix != null) 
                    {
                        if (location.Links != null) 
                        {
                            location.Links = location.Links.Select(it => ApplyLinkPrefix(it, linkPrefix)).ToList();
                        }
                        if (location.Actions != null) {
                            location.Actions = location.Actions.Select(it => ApplyActionPrefix(it, linkPrefix)).ToList();
                        }
                    }
                    context.Response.StatusCode = 200;
                    var accept = context.Request.Headers["Accept"];
                    var renderer = ChooseRenderer(accept[0]);
                    var s = renderer.Render(location);
                    context.Response.Headers.Add("content-type", renderer.ContentType);
                    await context.Response.WriteAsync(s);
                }
                catch (ClientErrorException ex)
                {
                    context.Response.StatusCode = 400;
                    context.Response.Headers.Add("content-type", "text/plain");
                    await context.Response.WriteAsync(ex.Message);
                }
                catch (NotSupportedException)
                {
                    context.Response.StatusCode = 405;
                }
                catch (RedirectException ex)
                {
                    context.Response.StatusCode = ex.StatusCode;
                    context.Response.Headers.Add("location", ex.Location);
                }
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }

        private static Link ApplyLinkPrefix(Link link, string prefix) 
        {
            return new Link(link.Relation, $"/{prefix}{link.Value}");
        }

        private static Action ApplyActionPrefix(Action action, string prefix) 
        {
            var href = $"/{prefix}{action.Href}";
            var result = new Action(action.Name, action.Method, href, action.Title);
            foreach (var f in action.Fields) {
                result.AddField(f);
            }
            return result;
        }

        public async Task Handle(HttpContext context, string gameId, string resourceName)
        {
            if (_games.TryGetValue(gameId, out var gameHandler)) 
            {
                if (resourceName == "play-again")
                {
                    _games.Remove(gameId);
                    await ToStart(context);
                }
                else 
                {
                    var resource = gameHandler.LookupResource(resourceName);
                    await HandleResource(context, resource, gameId);
                }
            }
            else
            {
                Console.WriteLine($"/{gameId}/{resourceName}: Couldn't find game '{gameId}'");
                await ToStart(context);
            }
        }
   }
}
