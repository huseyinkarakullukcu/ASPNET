using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); //controller ların view ile ilişkilendirilmesi


builder.Services.AddDbContext<BlogContext>(options =>{
    // var config = builder.Configuration;
    // var connectionString = config.GetConnectionString("sql_connection");
    // options.UseSqlite(connectionString);

    options.UseSqlite(builder.Configuration["ConnectionStrings:sql_connection"]);

    // var version = new MySqlServerVersion(new Version());
    // options.UseMySql(connectionString, version);
});

//Sanalı çağırdığımızda bize gerçeğini gönderecek.
builder.Services.AddScoped<IPostRepository, EfPostRepository>();

var app = builder.Build();

SeedData.TestVerileriniDoldur(app);

app.MapDefaultControllerRoute(); //controller view id

app.Run();
