using Microsoft.Extensions.Caching.Distributed;

namespace appRedis.Infra.Caching;

public class CachingService : ICachingService
{
    private readonly IDistributedCache _cache;
    private readonly DistributedCacheEntryOptions _options;

    public CachingService(IDistributedCache cache, DistributedCacheEntryOptions options)
    {
        _cache = cache;

        _options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
            SlidingExpiration = TimeSpan.FromSeconds(1200)
        };
    }


    public async Task Set(string key, string value)
    {
        await _cache.SetStringAsync(key, value, _options);
    }

    public async Task<string> Get(string key)
    {
        return await _cache.GetStringAsync(key) ?? string.Empty;
    }
}