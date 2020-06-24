using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleCMS.Application.Common.Interfaces;

namespace SimpleCMS.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SimpleDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SimpleDatabase"));
            });

            services.AddScoped<ISimpleDbContext>(provider => provider.GetService<SimpleDbContext>());

            return services;
        }
    }
}
