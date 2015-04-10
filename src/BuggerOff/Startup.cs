using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Data.Entity;
using Data_Layer.Contexts;
using Data_Layer.Commands.Bug;

namespace BuggerOff
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
			
        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddEntityFramework()
				.AddSqlServer()
				.AddDbContext<BugContext>();

            services.AddMvc();

			services.AddSingleton<IBugCommandHandler, BugCommandHandler>();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // app.UseStaticFiles();
            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
