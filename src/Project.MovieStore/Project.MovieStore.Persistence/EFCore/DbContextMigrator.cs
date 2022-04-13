using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MovieStore.Persistence.EFCore
{
    public class DbContextMigrator
    {
        public MovieStoreDbContext _context { get; set; }
        public DbContextMigrator(MovieStoreDbContext context)
        {
            _context = context;
        }

        public void Migrate()
        {
            _context.Database.Migrate();
        }

    }
}
