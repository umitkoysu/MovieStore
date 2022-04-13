using Project.MovieStore.Application.Services.Movies.Dto;

namespace Project.MovieStore.Application.Services.Categories.Dto
{
    public class CategoryGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  List<MovieGetDto> Movies { get; set; }

    }
}