namespace BlogPortfolio;

// Creates a project model 
public class Project
{
    // Requires ID, Title, Description, Image, TechStack (list)
    // and a GitHub URL, and nullable deployed URL
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string FeaturedImageUrl { get; set; }
    public string[] TechStack { get; set; }
    public string GitHubUrl { get; set; }
    public string? DeployedUrl { get; set; }
}
