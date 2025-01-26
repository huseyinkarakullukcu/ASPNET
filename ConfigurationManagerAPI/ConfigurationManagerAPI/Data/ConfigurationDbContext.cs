using ConfigurationManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationManagerAPI.Data
{
    public class ConfigurationDbContext:DbContext
    {
        public ConfigurationDbContext(DbContextOptions<ConfigurationDbContext> options) : base(options) { }

        public DbSet<ConfigurationModel> Configurations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfigurationModel>().HasData(
                new ConfigurationModel { Id = 1, Name = "SiteName", Type = "string", Value = "soty.io", IsActive = true, ApplicationName = "SERVICE-A" },
                new ConfigurationModel { Id = 2, Name = "IsBasketEnabled", Type = "bool", Value = "true", IsActive = true, ApplicationName = "SERVICE-B" },
                new ConfigurationModel { Id = 3, Name = "MaxItemCount", Type = "int", Value = "50", IsActive = false, ApplicationName = "SERVICE-A" }
            );
        }
    }
}
