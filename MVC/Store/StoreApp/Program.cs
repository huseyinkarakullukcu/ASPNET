using Microsoft.EntityFrameworkCore;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

//service ekleme - middleware
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RepositoryContext>(options =>
{//connection bağlantı middleware - veritabanı kullanmak için
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
    b=>b.MigrationsAssembly("StoreApp"));
});

var app = builder.Build();

//wwwroot static klasörünü kullanabilmek içib
app.UseStaticFiles();

//app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}");

app.Run();
