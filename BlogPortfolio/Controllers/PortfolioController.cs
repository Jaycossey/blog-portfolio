using BlogPortfolio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Collections.Immutable;
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

    //
    // GET: /Portfolio/Create
    public IActionResult Create()
    {
        // returns create post view
        return View();
    }

    //
    // POST: /Portfolio/Create
    [HttpPost]
    public IActionResult Create(Project model)
    {
        _context.Projects.Add(model);
        _context.SaveChanges();
        return View();
    }

    // 
    // GET: /Portfolio/Edit/
    [HttpGet]
    public IActionResult Edit(Guid? id)
    {
        // Returns a view for editing the data
        var project = _context.Projects.Where(x => x.Id == id).FirstOrDefault();

        return View(project);
    }
    //
    // POST: /Portfolio/Edit
    [HttpPost]
    public IActionResult Edit(Project model)
    {
        // find matching model with ID
        var data = _context.Projects.Where(x => x.Id == model.Id).FirstOrDefault();

        if (data != null)
        {
            data.Title = model.Title;
            data.TechStack = model.TechStack;
            data.Description = model.Description;
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }


}
