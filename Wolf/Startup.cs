using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

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

    public class Field
    {
        private readonly string _name;

        public Field(string name)
        {
            _name = name;
        }

        public string Name => _name;

        public string Type { get; set; }

        public string Title { get; set; }

        public string Value { get; set; }
    }

    public class Action 
    { 
        private readonly string _name;
        private readonly string _method;
        private readonly string _href;
        private readonly string _title;
        private readonly List<Field> _fields;

        public Action(string name, string method, string href, string title)
        {
            _name = name;
            _method = method;
            _href = href;
            _title = title;
            _fields = new List<Field>();
        }

        public string Name => _name;
        public string Method => _method;
        public string Href => _href;
        public string Title => _title;

        public void AddField(Field field) => _fields.Add(field);

        public IReadOnlyList<Field> Fields => _fields;
    }

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
        private readonly List<Thing> _things = new List<Thing>();

        public abstract string Id { get; }

        public abstract string Title { get; }

        public abstract Representation Visit(Player player);

        public IReadOnlyList<Thing> Things => _things;

        public void Add(Thing thing)
        {
            _things.Add(thing);
        }

        public Representation PickUp(Player player, string thingId)
        {
            player.Keep(Take(thingId));
            return Visit(player);
        }

        private Thing Take(string thingId)
        {
            var item = _things.FirstOrDefault(it => thingId == it.Id);
            if (item == null)
            {
                throw new Exception($"No such item: {thingId}");
            }

            _things.Remove(item);

            return item;
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
            //var playerHandler = new PlayerHandler(game);
            //game.Player.Keep(new Torch());
            var handler = new GameRequestHandler(game);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => await handler.Start(context));

                foreach (var name in handler.ResourceNames)
                {
                    endpoints.Map(name, async context => await handler.Handle(context, name));
                }
            });
        }
    }
}
