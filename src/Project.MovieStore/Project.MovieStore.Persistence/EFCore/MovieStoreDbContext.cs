using Microsoft.EntityFrameworkCore;
using Project.MovieStore.Domain.Abstract;
using Project.MovieStore.Domain.Entities;
using System.Reflection;


namespace Project.MovieStore.Persistence.EFCore
{
    public class MovieStoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        public MovieStoreDbContext( DbContextOptions options) : base(options)
        {

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IErasableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.Entity.IsDeleted = true;
                        entry.State = EntityState.Modified;
                        break;

                    case EntityState.Added:
                        entry.Entity.IsDeleted = false;
                        break;
                }
            }

            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = entry.Entity.CreatedDate ?? DateTime.UtcNow.ToUniversalTime();
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = entry.Entity.ModifiedDate ?? DateTime.UtcNow.ToUniversalTime();
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
