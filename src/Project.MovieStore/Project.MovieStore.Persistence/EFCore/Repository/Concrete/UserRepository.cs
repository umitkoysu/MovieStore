using Project.MovieStore.Domain.Entities;
using Project.MovieStore.Persistence.EFCore.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MovieStore.Persistence.EFCore.Repository.Concrete
{
    public class UserRepository : Repository<User> , IUserRepository
    {
        public UserRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
    
}
