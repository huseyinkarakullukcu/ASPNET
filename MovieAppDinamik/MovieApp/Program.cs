using Microsoft.EntityFrameworkCore;
using MovieApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MovieContext>(options =>
{
    
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("SqlServerConnection");
    //options.UseSqlite(connectionString);
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
DataSeeding.Seed(app);
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
