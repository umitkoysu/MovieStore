using Project.MovieStore.Domain.Entities;
using Project.MovieStore.Persistence.EFCore.Repository.Abstract;

namespace Project.MovieStore.Persistence.EFCore.Repository.Concrete
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
    
}