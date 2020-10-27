using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleCMS.API.Common;
using SimpleCMS.Application;
using SimpleCMS.Application.Common.Interfaces;
using SimpleCMS.Persistence;
using System.Text;

namespace SimpleCMS.API
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
            services.AddCors(options => options.AddPolicy("Cors", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddPersistence(Configuration);
            services.AddApplication();

            services
                .AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ISimpleDbContext>());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "SimpleCMS API";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Cors");

            app.UseMiddleware<CustomExceptionHandlerMiddleware>();

            app.UseOpenApi();

            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
            });

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
                sb.Append("<div style='text-align:center;'>");
                sb.Append("<h1>SimpleCMS</h1>");
                sb.Append("<h3>Welcome to SimpleCMS");
                sb.Append("<p>Check out the API docs <a href='/api'>here</a></p>");
                sb.Append("</div>");
                await context.Response.WriteAsync(sb.ToString());
            }));
        }
    }
}
