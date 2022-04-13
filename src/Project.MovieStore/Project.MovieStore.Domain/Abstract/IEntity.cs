using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MovieStore.Domain.Abstract
{
    public interface IEntity<T> : IBaseEntity
    {
        public T Id { get; set; }
    }
}
