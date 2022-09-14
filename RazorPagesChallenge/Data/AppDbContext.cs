using Microsoft.EntityFrameworkCore;
using RazorPagesChallenge.Model;

namespace RazorPagesChallenge.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }

    }
}
