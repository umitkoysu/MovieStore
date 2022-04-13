using Project.MovieStore.Domain.Entities;

namespace Project.MovieStore.Persistence.EFCore.Repository.Abstract
{
    public interface IMovieRepository : IRepository<Movie>
    {
    }
    
}