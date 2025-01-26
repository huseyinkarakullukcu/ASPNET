using ConfigurationManagerAPI.Data;
using Microsoft.EntityFrameworkCore;
namespace ConfigurationManagerAPI.Services
{
    public class ConfigurationReader
    {
        private readonly ConfigurationDbContext _dbContext;
        private readonly string _applicationName;

        public ConfigurationReader(ConfigurationDbContext dbContext, string applicationName)
        {
            _dbContext = dbContext;
            _applicationName = applicationName;
        }

        private Dictionary<string, string> _cache = new();

        public async Task<T?> GetValueAsync<T>(string key)
        {
            try
            {
                var config = await _dbContext.Configurations
                    .FirstOrDefaultAsync(c => c.Name == key && c.ApplicationName == _applicationName && c.IsActive);

                if (config != null)
                {
                    _cache[key] = config.Value; // Cache'e kaydet
                    return (T)Convert.ChangeType(config.Value, typeof(T));
                }

                return default;
            }
            catch
            {
                // Depolamaya erişim başarısız, cache'teki son değeri döndür
                if (_cache.TryGetValue(key, out var cachedValue))
                {
                    return (T)Convert.ChangeType(cachedValue, typeof(T));
                }
                return default;
            }
        }
    }
}
