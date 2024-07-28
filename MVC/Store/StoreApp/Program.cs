using Microsoft.EntityFrameworkCore;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

//service ekleme - middleware
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RepositoryContext>(options =>
{//connection bağlantı middleware - veritabanı kullanmak için
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"));
});

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}");

app.Run();
