// imports
using BlogPortfolio.Models;
using Microsoft.EntityFrameworkCore;

// sets namespace
namespace BlogPortfolio.Data
{
    // Creates a dbcontext class
    public class BlogPortfolioDbContext : DbContext
    {
        // constructor function to map the context to the application
        public BlogPortfolioDbContext(DbContextOptions<BlogPortfolioDbContext> options) : base(options)
        {
        }

        // Creates a DbSet property for the BlogPost entity corresponding
        // to a table in the database
        public DbSet<BlogPost> BlogPosts { get; set; }

        // Create a dbset prop for Project models
        public DbSet<Project> Projects { get; set; }
    }
}
