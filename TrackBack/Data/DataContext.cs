using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackBack.Models;

namespace TrackBack.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {}

        public DbSet<Project> Projects { get; set; }

        public DbSet<Bookmark> Bookmarks { get; set; }
    }
}
