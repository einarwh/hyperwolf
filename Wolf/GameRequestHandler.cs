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

            var random = new Random();

            _resources = new Dictionary<string, Resource>
            {
                { "/player", new PlayerResource(_game) },
                { "/location", new LocationResource(_game) },
                { "/shop", new ShopResource(_game, new Shop()) },
                { "/hallway", new PlaceResource(_game, new Hallway()) },
                { "/audience-chamber", new PlaceResource(_game, new AudienceChamber()) },
                { "/great-hall", new PlaceResource(_game, new GreatHall()) },
                { "/meeting-room", new PlaceResource(_game, new MeetingRoom()) },
                { "/inner-hallway", new PlaceResource(_game, new InnerHallway()) },
                { "/entrance", new PlaceResource(_game, new Entrance()) },
                { "/kitchen", new PlaceResource(_game, new Kitchen()) },
                { "/store-room", new PlaceResource(_game, new StoreRoom()) },
                { "/lift", new PlaceResource(_game, new Lift()) },
                { "/rear-vestibule", new PlaceResource(_game, new RearVestibule()) },
                { "/castle-exit", new PlaceResource(_game, new CastleExit()) },
                { "/dungeon", new PlaceResource(_game, new Dungeon()) },
                { "/guard-room", new PlaceResource(_game, new GuardRoom()) },
                { "/master-bedroom", new PlaceResource(_game, new MasterBedroom()) },
                { "/upper-hallway", new PlaceResource(_game, new UpperHallway()) },
                { "/treasury", new PlaceResource(_game, new Treasury(random)) },
                { "/chambermaids-room", new PlaceResource(_game, new ChambermaidsRoom()) },
                { "/dressing-chamber", new PlaceResource(_game, new DressingChamber()) },
                { "/small-room", new PlaceResource(_game, new SmallRoom()) }
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
            context.Response.Headers.Add("location", "/entrance");
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
                    context.Response.StatusCode = 307;
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
