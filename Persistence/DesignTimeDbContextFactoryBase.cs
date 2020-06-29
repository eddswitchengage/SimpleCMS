using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SimpleCMS.Persistence
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        private const string CONNECTIONSTRINGNAME = "SimpleDatabase";
        private const string STARTUPPROJECTDIRECTORY = "API";

        public TContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}{1}", Path.DirectorySeparatorChar, STARTUPPROJECTDIRECTORY);

            Console.WriteLine($"DesignTimeDbContextFactoryBase.CreateDbContext(string[]): Base path: {basePath}");

            //For some reason the netcore env variable is never set when I run Add-Migration so I set it to Development here to add migrations
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");

            return Create(basePath, Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
        }

        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        private TContext Create(string basePath, string environmentName)
        {
            Console.WriteLine($"Create(string, string): Environment: {environmentName}");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString(CONNECTIONSTRINGNAME);

            return Create(connectionString);
        }

        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string '{nameof(connectionString)}' is null or empty");
            }

            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return CreateNewInstance(optionsBuilder.Options);
        }
    }
}
