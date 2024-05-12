using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlogPortfolio.Data;
using System;
using System.Linq;

namespace BlogPortfolio.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BlogPortfolioDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<BlogPortfolioDbContext>>()))
            {
                // check if any blog post data exists
                if (context.BlogPosts.Any() && context.Projects.Any())
                {
                    // End program if data exists
                    return;
                }

                // Create and update db with seed data
                // context.BlogPosts.AddRange(
                //     new BlogPost
                //     {
                //         Title = "ASP.NET MVC Architecture",
                //         Author = "Jaycossey",
                //         ShortDescription = "A look at the architecture for ASP.NET's Model View Controller design paradigm.",
                //         Content = "Lorem Ipsum",
                //         PublishedDate = DateTime.Now.Date
                //     },
                //     new BlogPost
                //     {
                //         Title = "dotnet Cheatsheet",
                //         Author = "Jaycossey",
                //         ShortDescription = "Dotnet cli cheatsheet",
                //         Content = "Lorem Ipsum",
                //         PublishedDate = DateTime.Now.Date
                //     },
                //     new BlogPost
                //     {
                //         Title = "Linux Commands Cheatsheet",
                //         Author = "Jaycossey",
                //         ShortDescription = "Linux Terminal command reference sheet.",
                //         Content = "Lorem Ipsum",
                //         PublishedDate = DateTime.Now.Date
                //     },
                //     new BlogPost
                //     {
                //         Title = "JavaScript and React.JS",
                //         Author = "Jaycossey",
                //         ShortDescription = "Fun JavaScript and React.JS methods",
                //         Content = "Lorem Ipsum",
                //         PublishedDate = DateTime.Now.Date
                //     }
                // );

                context.Projects.AddRange(
                    new Project
                    {
                        Title = "Client Side Web App",
                        Description = "Website created for a P&L Tunes",
                        FeaturedImageUrl = "test/file/path",
                        TechStack = ["HTML", "CSS", "JavaScript", "TailwindCSS", "React.JS"],
                        GitHubUrl = "https://github.com/Jaycossey/pandl",
                        DeployedUrl = "http://pandltunes.co.uk/"
                    },
                    new Project
                    {
                        Title = "Algorithms(WIP)",
                        Description = "Personal practice with algorithms",
                        FeaturedImageUrl = "/test/url",
                        TechStack = ["JavaScript", "Jest", "Node.JS"],
                        GitHubUrl = "https://github.com/Jaycossey/algorithms"
                    }
                );

                context.SaveChanges();
            }
    }
}