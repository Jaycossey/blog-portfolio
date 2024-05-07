using BlogPortfolio.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace BlogPortfolio;

public class BlogController : Controller
{
    // dependency injection 
    private readonly BlogPortfolioDbContext _context;
    public BlogController(BlogPortfolioDbContext context)
    {
        // assigns the context relational mapping for the 
        // controller
        _context = context;
    }
    // 
    // GET: /Blog/HelloWorld/
    public string HelloWorld()
    {
        // Navigate to localhost:<PORT>/HelloWorld
        // to see the returned string
        return "Hello World!";
    }
    // 
    // GET: /Blog/{name}/{num}
    public string PassData(string name, int num = 42)
    {
        // Returns string with passed data
        return $"Hello, {name}! The current date and time are: {DateTime.Now}\nMy favorite number is: {num}";
    }

    // 
    // GET: /Blog/
    public IActionResult Index()
    {
        // returns the /Views/Blog/Index.cshtml file
        // the view is positioned in the /Views/Shared/_Layout.cshtml
        // in the RenderBody() method.
        return View();
    }

    //
    // GET: /Blog/Post/{index}
    // Side Note ^^ this is not fully functional
    // I need to create the model and seed data before 
    // adding the functionality here.
    public IActionResult Details()
    {
        return View();
    }

    // 
    // GET: /Blog/Create/
    public IActionResult Create()
    {
        // Returns a create view to handle creation of
        // blog posts.

        return View();
    }
    //
    // GET: /Blog/Update/
    public IActionResult Update()
    {
        // Returns the update Blog view

        return View();
    }
    //
    // GET: /Blog/Delete/
    public IActionResult Delete()
    {
        // returns the delete blog view (confirmation warning)
        return View();
    }
}


/*
    Notes:
        The BlogController class is the constructor for the endpoints
        using the child class / method names as the action for the Blog 
        endpoint.

        We can pass data to views using the arguments as extensions to the 
        endpoints. The /Blog/PassData endpoint takes name and num as params.
        To ensure this endpoint works in the comment (line 26) we add in some 
        code in our Program.cs file. (line 44)
*/