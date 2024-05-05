using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace BlogPortfolio;

public class BlogController : Controller
{
    // 
    // GET: /Blog/HelloWorld/
    public string HelloWorld()
    {
        // Navigate to localhost:<PORT>/HelloWorld
        // to see the returned string
        return "Hello World!";
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
}

/*
    Notes:
        The BlogController class is the constructor for the endpoints
        using the child class / method names as the action for the Blog 
        endpoint.
*/