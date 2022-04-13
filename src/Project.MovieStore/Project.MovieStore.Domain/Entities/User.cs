using Project.MovieStore.Domain.Abstract;
using BC = BCrypt.Net.BCrypt;


namespace Project.MovieStore.Domain.Entities
{
    public class User : IEntity<int>, IAuditableEntity , IErasableEntity 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual List<Movie> Movies { get; set; }


       

    }
}
