using Project.MovieStore.Application.Results;
using Project.MovieStore.Application.Services.Users.Dto;
using Project.MovieStore.Domain.Entities;

namespace Project.MovieStore.Application.Services
{
    public interface IUserService
    {
        Task<ServiceResult<UserGetDto>> AddAsync(UserAddDto data);
        Task<BaseServiceResult> DeleteAsync(int id);
        Task<ServiceResult<List<UserGetDto>>> GetAllAsync();
        Task<ServiceResult<UserGetDto>> GetAsync(int id);
        Task<User> GetUserByMailOrUserName(string userNameOrEmail);
        Task<BaseServiceResult> PatchPasswordAsync(int id, UserPatchPasswordDto data);
        Task<ServiceResult<UserGetDto>> UpdateAsync(int id, UserUpdateDto data);
        bool ValidPassword(string password, string hashPassword);
    }
}