using Project.MovieStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MovieStore.Persistence.EFCore.Repository.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
