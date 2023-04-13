using _04CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace _04CodeFirst.Data
{
    public class CodeFirstDBContext : DbContext
    {
        public CodeFirstDBContext(DbContextOptions<CodeFirstDBContext> options) : base(options)
        {
            
        }

        public DbSet<Article> Articles { get; set; }
    }
}
