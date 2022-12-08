namespace RedisCacheInfrastructure.RedisCacheService
{
    public interface IRedisCacheService
    {
        T Get<T>(string key);

        void Add<T>(string key, T data);

        void Remove(string key);

        bool Any(string key);
    }
}
