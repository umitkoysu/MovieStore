using Project.MovieStore.Domain.Entities;
using Project.MovieStore.Persistence.EFCore.Repository.Abstract;

namespace Project.MovieStore.Persistence.EFCore.Repository.Concrete
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
    
}