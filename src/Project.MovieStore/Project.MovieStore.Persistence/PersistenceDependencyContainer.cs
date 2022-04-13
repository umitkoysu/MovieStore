using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.MovieStore.Persistence.EFCore;
using Project.MovieStore.Persistence.EFCore.Repository.Abstract;
using Project.MovieStore.Persistence.EFCore.Repository.Concrete;
using System;
using System.Reflection;

namespace Project.MovieStore.Persistence
{
    public static class PersistenceDependencyContainer
    {
        public static void AddPersistenceDependencyContainer(this IServiceCollection services, IConfiguration configuration)
        {
            var dbConfig = configuration.GetSection("Database");
            var provider = dbConfig["Provider"].ToLower();
            var connectionString = dbConfig["ConnectionString"];

            services.AddDbContext<MovieStoreDbContext>(options => {
                options.UseNpgsql(connectionString, x => x.MigrationsAssembly("Project.MovieStore.Persistence"));
            });

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();  
            services.AddScoped<DbContextMigrator>();  
        }
    }
}
