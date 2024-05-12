using BlogPortfolio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Text.Encodings.Web;

namespace BlogPortfolio;

public class PortfolioController : Controller
{
    private readonly BlogPortfolioDbContext _context;

    public PortfolioController(BlogPortfolioDbContext context)
    {
        _context = context;
    }

    // 
    // GET: /Portfolio/
    public async Task<IActionResult> Index()
    {
        return View(await _context.Projects.ToListAsync());
    }
}
