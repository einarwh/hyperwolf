using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Wolf
{
    public class Startup
    {
        private readonly MainRequestHandler _main = new MainRequestHandler();

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<Timekeeper>(sp => new Timekeeper(_main));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            var insights = new InsightsRequestHandler(_main);

            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/insights", async context => await insights.Handle(context));
                endpoints.Map("/start", async context => await _main.Start(context));
                endpoints.Map("/{gameId}/{resourceName}", async (HttpContext context, string gameId, string resourceName) => await _main.Handle(context, gameId, resourceName));
                endpoints.MapFallback(async context => await _main.ToStart(context));
            });
        }
    }
}
