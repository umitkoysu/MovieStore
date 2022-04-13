using Project.MovieStore.Application.Services.Movies.Dto;

namespace Project.MovieStore.Application.Services.Users.Dto
{
    public class UserGetSummaryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; }
    }
}