using Entites.Models;
using Microsoft.EntityFrameworkCore;

namespace Sport.Entites
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        { }
        public DbSet<User> Users { get; set; }
    }
}
