using AutoMapper;
using Project.MovieStore.Application.Results;
using Project.MovieStore.Application.Services.Movies.Dto;
using Project.MovieStore.Domain.Entities;
using Project.MovieStore.Persistence.EFCore.Repository.Abstract;

namespace Project.MovieStore.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }


        public async Task<ServiceResult<List<MovieGetDto>>> GetAllAsync()
        {
            var result = new ServiceResult<List<MovieGetDto>>();

            return result.Build(await _movieRepository.GetAllAsync(includeProperties:"User"));
        }

        public async Task<ServiceResult<MovieGetDto>> GetAsync(int id)
        {
            var result = new ServiceResult<MovieGetDto>();
            return result.Build(await _movieRepository.GetAsync(predicate: x => x.Id == id , includeProperties:"User"));
        }

        public async Task<ServiceResult<MovieGetDto>> AddAsync(MovieAddOrUpdateDto data)
        {
            var result = new ServiceResult<MovieGetDto>();
            var record = _mapper.Map<Movie>(data);

            var category = await _categoryRepository.GetByIdAsync(data.CategoryId);

            record.Categories.Add(category);

            await _movieRepository.AddAsync(record);
            await _movieRepository.SaveAsync();

            return result.Build(await _movieRepository.GetByIdAsync(record.Id));
        }

        public async Task<ServiceResult<MovieGetDto>> UpdateAsync(int id, MovieAddOrUpdateDto data)
        {
            var result = new ServiceResult<MovieGetDto>();
            var record = await _movieRepository.GetAsync(predicate: x => x.Id == id , includeProperties :"Categories");

            record.Title = data.Title;
            record.Description = data.Description;

            var category = await _categoryRepository.GetByIdAsync(data.CategoryId);
            record.Categories.Clear();
            record.Categories.Add(category);

            await _movieRepository.UpdateAsync(record);
            await _movieRepository.SaveAsync();

            return result.Build(await _movieRepository.GetByIdAsync(record.Id));
        }


        public async Task<BaseServiceResult> DeleteAsync(int id)
        {
            var result = new BaseServiceResult();

            await _movieRepository.DeleteAsync(id);
            result.CheckSuccess(await _movieRepository.SaveAsync());

            return result;
        }

    }
}