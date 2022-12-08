using Newtonsoft.Json;
using RedisCacheInfrastructure.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisCacheInfrastructure.RedisCacheService
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IRedisConnectionFactory _connection;

        private readonly IDatabase _database;

        public RedisCacheService(IRedisConnectionFactory connection)
        {
            _connection = connection;
            _database = _connection.Connection().GetDatabase(0);
        }

        public void Add<T>(string key, T data)
        {
            string jsonData = JsonConvert.SerializeObject(data);

            _database.StringSet(key, jsonData);
        }

        public bool Any(string key)
        {
            return _database.KeyExists(key);
        }

        public T Get<T>(string key)
        {
            if (!Any(key))
            {
                return default(T);
            }

            string jsonData = _database.StringGet(key);

            return JsonConvert.DeserializeObject<T>(jsonData);
        }

        public void Remove(string key)
        {
            _database.KeyDelete(key);
        }
    }
}
