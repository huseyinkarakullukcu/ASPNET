using ConfigurationManagerAPI.Data;
using ConfigurationManagerAPI.Models;
using ConfigurationManagerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ConfigurationManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly ConfigurationDbContext _dbContext;

        public ConfigurationController(ConfigurationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? appName = null)
        {
            var query = _dbContext.Configurations.AsQueryable();

            if (!string.IsNullOrEmpty(appName))
            {
                query = query.Where(c => c.ApplicationName == appName);
            }

            return Ok(await query.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ConfigurationModel model)
        {
            _dbContext.Configurations.Add(model);
            await _dbContext.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ConfigurationModel model)
        {
            var existing = await _dbContext.Configurations.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Name = model.Name;
            existing.Type = model.Type;
            existing.Value = model.Value;
            existing.IsActive = model.IsActive;
            existing.ApplicationName = model.ApplicationName;

            await _dbContext.SaveChangesAsync();
            return Ok(existing);
        }

        [HttpGet("dynamic-value/{appName}/{key}")]
        public async Task<IActionResult> GetDynamicValue(string appName, string key)
        {
            var configurationReader = new ConfigurationReader(_dbContext, appName);
            var value = await configurationReader.GetValueAsync<string>(key);

            if (value == null) return NotFound("Key not found or inactive.");
            
            return Ok(value);
        }
    }
}
