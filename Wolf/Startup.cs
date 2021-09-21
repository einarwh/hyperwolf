using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace Wolf
{
    public class Link 
    {
        public Link(string relation, string value)
        {
            Relation = relation;
            Value = value;
        }

        public string Relation { get; }

        public string Value { get; }
    }

    public class Action { }

    public class Title
    {
        private string _s;

        public Title(string s)
        {
            _s = s;
        }

        public override string ToString()
        {
            return _s;
        }
    }

    public class Description
    {
        private string _s;

        public Description(string s)
        {
            _s = s;
        }

        public override string ToString()
        {
            return _s;
        }
    }

    public class Representation
    {
        public List<Link> Links { get; set; }

        public List<Action> Actions { get; set; }

        public Title Title { get; set; }

        public Description Description { get; set; }

        public Dictionary<string, object> Properties { get; set; }
    }

    public interface IContainer
    {
        void AddThing(Thing thing);
    }

    public abstract class Place
    {
        public abstract Representation Visit(Player player);
    }

    public class Thing 
    {
    
    }

    public class Torch : Thing
    {
        public override string ToString()
        {
            return "Torch";
        }

    }

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            var game = new Game();
            var playerHandler = new PlayerHandler(game);
            game.Player.Keep(new Torch());
            var handler = new GameRequestHandler(game);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/player", async context => await playerHandler.Handle(context));
                endpoints.MapGet("/provisions", async context => await handler.Handle(context, "provisions"));

                foreach (var name in handler.PlaceNames)
                {
                    endpoints.Map(name, async context => await handler.Handle(context, name));
                }
            });
        }
    }
}
