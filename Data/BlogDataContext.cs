// DataContext is made to map the database
// it's from the Entity framework
using Blog2.Data.Mappings;
using Blog2.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog2.Data
{
    public class BlogDataContext : DbContext // it's important that the class extends DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("server=localhost,1433;database=Blog;User Id=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
        }
    }
}