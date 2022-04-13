using AutoMapper;
using Project.MovieStore.Application.Results;
using Project.MovieStore.Application.Services.Categories.Dto;
using Project.MovieStore.Domain.Entities;
using Project.MovieStore.Persistence.EFCore.Repository.Abstract;

namespace Project.CategoryStore.Application.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public async Task<ServiceResult<List<CategoryGetDto>>> GetAllAsync()
        {
            var result = new ServiceResult<List<CategoryGetDto>>();

            return result.Build(await _categoryRepository.GetAllAsync(includeProperties:"Movies"));
        }

        public async Task<ServiceResult<CategoryGetDto>> GetAsync(int id)
        {
            var result = new ServiceResult<CategoryGetDto>();

            return result.Build(await _categoryRepository.GetAsync(includeProperties: "Movies", predicate: x => x.Id == id));
        }

        public async Task<ServiceResult<CategoryGetDto>> AddAsync(CategoryAddOrUpdateDto data)
        {
            var result = new ServiceResult<CategoryGetDto>();
            var record = _mapper.Map<Category>(data);

            await _categoryRepository.AddAsync(record);
            await _categoryRepository.SaveAsync();

            return result.Build(await _categoryRepository.GetByIdAsync(record.Id));
        }

        public async Task<ServiceResult<CategoryGetDto>> UpdateAsync(int id, CategoryAddOrUpdateDto data)
        {
            var result = new ServiceResult<CategoryGetDto>();
            var record = await _categoryRepository.GetByIdAsync(id);

            record.Name = data.Name;

            await _categoryRepository.UpdateAsync(record);
            await _categoryRepository.SaveAsync();

            return result.Build(await _categoryRepository.GetByIdAsync(record.Id));
        }


        public async Task<BaseServiceResult> DeleteAsync(int id)
        {
            var result = new BaseServiceResult();

            await _categoryRepository.DeleteAsync(id);
            result.CheckSuccess(await _categoryRepository.SaveAsync());

            return result;
        }

    }
}