using System.ComponentModel.DataAnnotations;

namespace BlogPortfolio;

public class BlogPost
{
    // Models are classes, containing the table formatted 
    // representation of the data, in this case, the BlogPost
    // table needs:
    // 
    // A unique ID 
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    // The DateTime typed published date
    [DataType(DataType.Date)]
    public DateTime PublishedDate { get; set; }
    public string ShortDescription {get; set; }
    public string Content { get; set; }
}
// Each element within the table has a getter and setter 