using Microsoft.EntityFrameworkCore;
using TrackBack.Models;

namespace TrackBack.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Bookmark> Bookmarks { get; set; }

        public DbSet<Todo> Todos { get; set; }
    }
}
