using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wolf
{
    public class GameRequestHandler
    {
        private int _visits = 0;
        private readonly Game _game;
        private readonly Dictionary<string, Place> _places;

        public GameRequestHandler(Game game)
        {
            _game = game;
            _places = new Dictionary<string, Place>
            {
                { "/hallway", new Hallway() },
                { "/audience-chamber", new AudienceChamber() },
                { "/great-hall", new GreatHall() },
                { "/meeting-room", new MeetingRoom() },
                { "/inner-hallway", new InnerHallway() },
                { "/entrance", new Entrance() },
                { "/kitchen", new Kitchen() },
                { "/store-room", new StoreRoom() },
                { "/lift", new Lift() },
                { "/rear-vestibule", new RearVestibule() },
                { "/castle-exit", new CastleExit() },
                { "/dungeon", new Dungeon() },
                { "/guard-room", new GuardRoom() },
                { "/master-bedroom", new MasterBedroom() },
                { "/upper-hallway", new UpperHallway() },
                { "/treasury", new Treasury() },
                { "/chambermaids-room", new ChambermaidsRoom() },
                { "/dressing-chamber", new DressingChamber() },
                { "/small-room", new SmallRoom() }
            };
        }

        private static IRenderer ChooseRenderer(string value)
        {
            //var ss = value.Split(",");
            return new HtmlRenderer();
        }

        public async Task Handle(HttpContext context, string resourceName)
        {
            if (_places.TryGetValue(resourceName, out var place))
            {
                var location = place.Visit(_game.Player);
                //++_visits;
                //var content = $"You've been here {_visits} time(s).";
                context.Response.StatusCode = 200;
                var accept = context.Request.Headers["Accept"];
                var renderer = ChooseRenderer(accept[0]);
                var s = renderer.Render(location);
                context.Response.Headers.Add("content-type", renderer.ContentType);
                await context.Response.WriteAsync(s);
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }

        public IEnumerable<string> PlaceNames => _places.Keys;
    }
}
