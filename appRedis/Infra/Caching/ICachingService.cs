namespace appRedis.Infra.Caching;

public interface ICachingService
{
    Task Set(string key, string value);
    Task<string> Get(string key);
}