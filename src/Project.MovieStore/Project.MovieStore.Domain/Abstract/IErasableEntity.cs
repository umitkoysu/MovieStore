
namespace Project.MovieStore.Domain.Abstract
{
    public interface IErasableEntity
    {
        public bool IsDeleted { get; set; }
    }
}
