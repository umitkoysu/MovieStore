using Project.MovieStore.Application.Services.Movies.Dto;

namespace Project.MovieStore.Application.Services.Users.Dto
{
    public class UserGetDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public List<MovieGetDto> Movies { get; set; }
        // public virtual User User  { get; set; }
        // public virtual List<Category> Categories { get; set; }        
    }
}