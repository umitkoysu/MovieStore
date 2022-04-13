using Project.MovieStore.Application.Results;
using Project.MovieStore.Application.Services.Movies.Dto;

namespace Project.MovieStore.Application.Services
{
    public interface IMovieService
    {
        Task<ServiceResult<MovieGetDto>> AddAsync(MovieAddOrUpdateDto data);
        Task<BaseServiceResult> DeleteAsync(int id);
        Task<ServiceResult<List<MovieGetDto>>> GetAllAsync();
        Task<ServiceResult<MovieGetDto>> GetAsync(int id);
        Task<ServiceResult<MovieGetDto>> UpdateAsync(int id, MovieAddOrUpdateDto data);
    }
}