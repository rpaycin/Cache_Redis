using StackExchange.Redis;

namespace RedisCacheInfrastructure.Configuration
{
    public interface IRedisConnectionFactory
    {
        ConnectionMultiplexer Connection();
    }
}
