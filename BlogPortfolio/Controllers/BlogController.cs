using BlogPortfolio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Text.Encodings.Web;

namespace BlogPortfolio;

// Controller for the Blog endpoints 
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
    // Note, the updated Index action method is now an async task, 
    // we call the async function to retrieve the data from the seeded database
    public async Task<IActionResult> Index()
    {
        // returns the /Views/Blog/Index.cshtml file
        // the view is positioned in the /Views/Shared/_Layout.cshtml
        // in the RenderBody() method.
        // 
        // When returning the view, we pass the listed blogposts via dependency
        // injection in order for us to list the items.
        return View(await _context.BlogPosts.ToListAsync());
    }

    //
    // GET: /Blog/Post/{id}
    public async Task<ActionResult> Details(Guid? id)
    {
        // If id param is null return 404
        if (id == null)
        {
            return NotFound();
        }

        // await result of data call from context when result matches GUID
        var blogPost = await _context.BlogPosts.SingleOrDefaultAsync(m => m.Id ==id);

        // ensure blog post exists
        if (blogPost == null)
        {
            return NotFound();
        }

        // pass the blogPost to the view
        return View(blogPost);
    }

    // 
    // GET: /Blog/Create/
    [HttpGet]
    public IActionResult Create()
    {
        // Returns a create view to handle creation of
        // blog posts.

        return View();
    }
    //
    // POST: /Blog/Create/
    [HttpPost]
    // Creates a new BlogPost Model and adds to database
    public IActionResult Create(BlogPost model)
    {
        _context.BlogPosts.Add(model);
        _context.SaveChanges();
        ViewBag.Message = "Blog Post Added to Database Successfully";
        return View();
    }
    //
    // GET: /Blog/Update/
    [HttpGet]
    public IActionResult Update(Guid? id)
    {
        // Returns the update Blog view
        var blogPost = _context.BlogPosts.Where(x => x.Id == id).FirstOrDefault();
        // Console.WriteLine(blogPost.Title);

        return View(blogPost);
    }
    //
    // POST: /Blog/Update/
    [HttpPost]
    public IActionResult Update(BlogPost model)
    {
        var data = _context.BlogPosts.Where(x => x.Id == model.Id).FirstOrDefault();
        // Check model exists, updates data within dbContext
        if (data != null)
        {
            data.Title = model.Title;
            data.Author = model.Author;
            data.PublishedDate = DateTime.Now.Date;
            data.ShortDescription = model.ShortDescription;
            data.Content = model.Content;
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
    //
    // GET: /Blog/Delete/
    [HttpDelete]
    public ActionResult Delete(Guid id)
    {
        // TODO:
        // Create a confirmation message which renders before continuing
        // this function. Rather than this being triggered by an <a> tag, 
        // I can instead change that with some JS. The button should be a
        // pre-cursor to this asp-action. Have a hidden button which has 
        // "confirm: y/n" this hidden button should be the asp-action. So
        // change the original link to be a basic button that has an onClick 
        // event handler to update the visibility on the confirmation button.
        var data = _context.BlogPosts.Where(x => x.Id == id).FirstOrDefault();
        
        
        if (data != null)
        {
            _context.BlogPosts.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Deleted Successfully";
        }
        return RedirectToAction("Index");
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

        IMPORTANT! When creating the Delete() endpoint, remember that if the 
        id param is nullable, then the program will throw an error on matching
        endpoints, essentially if null, the endpoint would try to target non 
        existant data. Ensuring that the param exists provides the target element 
        to be deleted.
*/