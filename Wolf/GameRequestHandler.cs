using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wolf
{
    public class GameRequestHandler
    {
        private readonly Game _game;
        private readonly Dictionary<string, Resource> _resources;

        public GameRequestHandler(Game game)
        {
            _game = game;

            _resources = new Dictionary<string, Resource>
            {
                { "/start", new StartResource(_game) },
                { "/death", new DeathResource(_game) },
                { "/player", new PlayerResource(_game) },
                { "/location", new LocationResource(_game) },
                { "/teleport", new TeleportResource(_game) },
                { "/shop", new ShopResource(_game) },
                { "/hallway", new PlaceResource(_game, _game.Hallway) },
                { "/audience-chamber", new PlaceResource(_game, _game.AudienceChamber) },
                { "/great-hall", new PlaceResource(_game, _game.GreatHall) },
                { "/meeting-room", new PlaceResource(_game, _game.MeetingRoom) },
                { "/inner-hallway", new PlaceResource(_game, _game.InnerHallway) },
                { "/entrance", new PlaceResource(_game, _game.Entrance) },
                { "/kitchen", new PlaceResource(_game, _game.Kitchen) },
                { "/store-room", new PlaceResource(_game, _game.StoreRoom) },
                { "/lift", new PlaceResource(_game, _game.Lift) },
                { "/rear-vestibule", new PlaceResource(_game, _game.RearVestibule) },
                { "/castle-exit", new PlaceResource(_game, _game.CastleExit) },
                { "/dungeon", new PlaceResource(_game, _game.Dungeon) },
                { "/guard-room", new PlaceResource(_game, _game.GuardRoom) },
                { "/master-bedroom", new PlaceResource(_game, _game.MasterBedroom) },
                { "/upper-hallway", new PlaceResource(_game, _game.UpperHallway) },
                { "/treasury", new PlaceResource(_game, _game.Treasury) },
                { "/chambermaids-room", new PlaceResource(_game, _game.ChambermaidsRoom) },
                { "/dressing-chamber", new PlaceResource(_game, _game.DressingChamber) },
                { "/small-room", new PlaceResource(_game, _game.SmallRoom) },
                { "/werewolf", new MonsterResource(_game, _game.Werewolf) },
                { "/fleshgorger", new MonsterResource(_game, _game.Fleshgorger) },
                { "/maldemer", new MonsterResource(_game, _game.Maldemer) },
                { "/dragon", new MonsterResource(_game, _game.Dragon) },
            };
        }

        private static IRenderer ChooseRenderer(string value)
        {
            //var ss = value.Split(",");
            return new HtmlRenderer();
        }

        public Task Start(HttpContext context)
        {
            context.Response.StatusCode = 307;
            context.Response.Headers.Add("location", "/start");
            return Task.CompletedTask;
        }

        public async Task Handle(HttpContext context, string resourceName)
        {
            if (_resources.TryGetValue(resourceName, out var resource))
            {
                try
                {
                    var location = resource.Request(context);
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

        public IEnumerable<string> ResourceNames => _resources.Keys;
    }
}
