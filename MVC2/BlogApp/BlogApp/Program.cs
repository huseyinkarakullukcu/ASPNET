using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
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
builder.Services.AddScoped<ITagRepository, EfTagRepository>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();

//kullanıcı işlemleri için
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var app = builder.Build();

app.UseStaticFiles(); //dosyalara erişimi açma wwwroot

//Kullanıcı işlemleri için
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

SeedData.TestVerileriniDoldur(app);

// app.MapDefaultControllerRoute(); //controller view id

//localhost://posts/react-dersleri
//localhost://posts/php-dersleri

app.MapControllerRoute(
    name:"post_details",
    pattern : "posts/details/{url}",
    defaults: new {controller="Posts", action="Details"}
);
//localhost://posts/tag/php
app.MapControllerRoute(
    name:"posts_by_tag",
    pattern : "posts/tag/{tag}",
    defaults: new {controller="Posts", action="Index"}
);

app.MapControllerRoute(
    name:"default",
    pattern : "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
