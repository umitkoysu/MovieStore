using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Project.CategoryStore.Application.Services;
using Project.MovieStore.Application.Authentication;
using Project.MovieStore.Application.Results;
using Project.MovieStore.Application.Services;

namespace Project.MovieStore.Application
{
    public static class ApplicationDependencyContainer
    {
        public static async Task AddApplicationDependencyContainer(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<JwtTokenBuilder>();
        }

    }
}