using Project.MovieStore.Application.Services.Movies.Dto;

namespace Project.MovieStore.Application.Services.Categories.Dto
{
    public class LoginPostDto
    {
        public string UserNameOrEEmail { get; set; }
        public string Password { get; set; }

    }
}