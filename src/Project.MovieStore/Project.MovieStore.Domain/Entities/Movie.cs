using Project.MovieStore.Domain.Abstract;

namespace Project.MovieStore.Domain.Entities
{
    public class Movie : IEntity<int>, IErasableEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int UserId { get; set; }
        public virtual User User  { get; set; }
        public virtual List<Category> Categories { get; set; }


    }
}
