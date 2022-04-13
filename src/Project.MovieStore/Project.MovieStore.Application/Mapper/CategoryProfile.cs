using AutoMapper;
using Project.MovieStore.Application.Services.Categories.Dto;
using Project.MovieStore.Domain.Entities;

namespace Project.CategoryStore.Application.Mapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddOrUpdateDto, Category>();
            CreateMap<Category,CategoryGetDto>();
        }
    }
}
