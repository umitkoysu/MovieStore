namespace Project.MovieStore.Application.Services.Movies.Dto
{
    public class MovieAddOrUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}