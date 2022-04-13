using AutoMapper;
using Project.MovieStore.Application.Services.Movies.Dto;
using Project.MovieStore.Domain.Entities;

namespace Project.MovieStore.Application.Mapper
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieAddOrUpdateDto, Movie>()
            .ForMember(x => x.Categories, d => d.MapFrom(y => new List<Category>()));    
            CreateMap<Movie,MovieGetDto>();
        }
    }
}
