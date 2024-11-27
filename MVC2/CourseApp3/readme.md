- dotnet new mvc
- .netframeworCore.Sqlite
- Entity
- DbContext
- Program.cs ConnectionString ekleme
    builder.Services.AddDbContext<DataContext>(options=>{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("database");
    options.UseSqlite(connectionString);
});
- appsetting.json
    "ConnectionStrings": {
    "database" : "Data Source=database.db"
  }

- Migrations, kullanmak için dotnet ef tool global alana kurulmalı

- Design paket kurulmalı
    
