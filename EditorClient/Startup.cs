using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleCMS.Application;
using SimpleCMS.Application.Common.Interfaces;
using SimpleCMS.Persistence;
using System.Text;

namespace EditorClient
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPersistence(Configuration);
            services.AddApplication();

            services
                .AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ISimpleDbContext>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            MapWelcomePage(app);
        }

        private void MapWelcomePage(IApplicationBuilder app)
        {
            app.Map("", builder => builder.Run(async context =>
            {
                var sb = new StringBuilder();
                sb.Append("<h1>SimpleCMS</h1>");
                sb.Append("<h3>Welcome to SimpleCMS");
                await context.Response.WriteAsync(sb.ToString());
            }));
        }
    }
}
