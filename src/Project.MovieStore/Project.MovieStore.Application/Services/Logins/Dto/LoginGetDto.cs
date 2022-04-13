using Project.MovieStore.Application.Results;
using Project.MovieStore.Application.Services.Users.Dto;

namespace Project.MovieStore.Application.Services.Categories.Dto
{
    public class LoginGetDto
    {
        public UserGetSummaryDto User { get; set; }

        public TokenBuilderResult Tokens { get; set; }
     
    }
}