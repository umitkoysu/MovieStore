using Project.MovieStore.Application.Results;
using Project.MovieStore.Application.Services.Categories.Dto;

namespace Project.CategoryStore.Application.Services
{
    public interface ICategoryService
    {
        Task<ServiceResult<CategoryGetDto>> AddAsync(CategoryAddOrUpdateDto data);
        Task<BaseServiceResult> DeleteAsync(int id);
        Task<ServiceResult<List<CategoryGetDto>>> GetAllAsync();
        Task<ServiceResult<CategoryGetDto>> GetAsync(int id);
        Task<ServiceResult<CategoryGetDto>> UpdateAsync(int id, CategoryAddOrUpdateDto data);
    }
}