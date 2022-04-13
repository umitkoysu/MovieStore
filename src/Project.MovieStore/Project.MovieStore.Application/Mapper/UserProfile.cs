using AutoMapper;
using Project.MovieStore.Application.Services.Movies.Dto;
using Project.MovieStore.Application.Services.Users.Dto;
using Project.MovieStore.Domain.Entities;

namespace Project.MovieStore.Application.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
            CreateMap<User,UserGetDto>();
            CreateMap<User,UserGetSummaryDto>();
        }
    }
}
