using Project.MovieStore.Application.Services.Users.Dto;
using Project.MovieStore.Domain.Entities;

namespace Project.MovieStore.Application.Services.Movies.Dto
{
    public class MovieGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual UserGetSummaryDto User  { get; set; }
               
    }
}