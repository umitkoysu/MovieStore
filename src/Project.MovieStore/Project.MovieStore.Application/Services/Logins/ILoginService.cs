using Project.MovieStore.Application.Results;
using Project.MovieStore.Application.Services.Categories.Dto;
using Project.MovieStore.Application.Services.Logins.Dto;

namespace Project.MovieStore.Application.Services
{
    public interface ILoginService
    {
        Task<ServiceResult<LoginGetDto>> LoginManagerAsync(LoginPostDto login);
        Task<ServiceResult<RefreshLoginGetDto>> RefReshLoginManagerAsync(int userId);
    }
}