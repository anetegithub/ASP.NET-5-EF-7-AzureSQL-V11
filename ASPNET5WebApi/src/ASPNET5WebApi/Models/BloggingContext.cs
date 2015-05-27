using Microsoft.Data.Entity;

namespace ASPNET5WebApi.Models
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"AzureSQLConnectionString");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ForSqlServer().UseIdentity();
        }
    }
}