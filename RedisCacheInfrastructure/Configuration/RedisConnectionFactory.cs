using StackExchange.Redis;
using System;

namespace RedisCacheInfrastructure.Configuration
{
    public class RedisConnectionFactory : IRedisConnectionFactory
    {
        private readonly Lazy<ConnectionMultiplexer> _connection;

        public RedisConnectionFactory()
        {
            if (_connection == null)
            {
                _connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect("localhost:6379,abortConnect=false"));//appsettings den alınabilir
            }
        }
        public ConnectionMultiplexer Connection()
        {
            return _connection.Value;
        }
    }
}
