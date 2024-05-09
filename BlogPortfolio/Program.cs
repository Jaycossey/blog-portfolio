using BlogPortfolio;
using BlogPortfolio.Data;
using BlogPortfolio.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Set connection string and mapping with dbcontext
// Note that the GetConnectionString() Method should reference the appsettings.json connectionstring
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<BlogPortfolioDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
}
else
{
    builder.Services.AddDbContext<BlogPortfolioDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

var app = builder.Build();

// Create and feed in the seedData 
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Blog Endpoint rebinding example
app.MapControllerRoute(
    name: "hello",
    // Note the controller, the action method, and the two params as queries in the url
    pattern: "{controller=Blog}/{action=PassData}/{name?}/{num?}"
);

// Route mapping for blogposts by ID filter
app.MapControllerRoute(
    name: "blogDetails",
    pattern: "{controller=Blog}/{action=Details}/{id?}"
);

app.MapControllerRoute(
    name: "edit",
    pattern: "{controller=Blog}/{action=Create}"
);

app.MapControllerRoute(
    name: "update",
    pattern: "{controller=Blog}/{action=Update}/{id?}"
);

app.MapControllerRoute(
    name: "delete",
    pattern: "{controller=Blog}/{action=Delete}/{id?}"
);


app.Run();
