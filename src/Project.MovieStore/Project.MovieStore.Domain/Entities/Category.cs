using Project.MovieStore.Domain.Abstract;


namespace Project.MovieStore.Domain.Entities
{
    public class Category : IEntity<int> , IErasableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<Movie> Movies { get; set; }


    }
}
