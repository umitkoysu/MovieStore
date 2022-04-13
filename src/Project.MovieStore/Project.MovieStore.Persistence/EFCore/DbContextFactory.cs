using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace Project.MovieStore.Persistence.EFCore
{
    public class DbContexFactory : IDesignTimeDbContextFactory<MovieStoreDbContext>
    {
        public MovieStoreDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                  .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Project.MovieStore.API"))
                  .AddJsonFile("appsettings.json")
                  .Build();

            var builder = new DbContextOptionsBuilder<MovieStoreDbContext>();

            var dbConfig = configuration.GetSection("Database");
            string? connectionString = dbConfig["ConnectionString"];
            var provider = dbConfig["Provider"].ToLower();
       
            builder.UseNpgsql(connectionString, x => x.MigrationsAssembly("Project.MovieStore.Persistence"));
           

            return new MovieStoreDbContext(builder.Options);
        }
    }
}
