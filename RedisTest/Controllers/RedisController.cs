using Microsoft.AspNetCore.Mvc;
using RedisCacheInfrastructure.RedisCacheService;

namespace RedisTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RedisController : ControllerBase
    {
        //https://www.youtube.com/watch?v=p-awJn51pZs
        /*
         * dockerda önce redisi ayağa kaldırman gerek
         * docker pull redis
         * docker run --name RedisDeneme -d redis         
        * */

        private readonly IRedisCacheService _redis;

        public RedisController(IRedisCacheService redis)
        {
            _redis = redis;
        }

        [HttpGet]
        public Customer Get()
        {
            var customer = _redis.Get<Customer>("testKey");

            return customer;
        }

        [HttpGet("AdKey")]
        public void AddKey()
        {
            _redis.Add<Customer>("testKey", new Customer { Age = 3, Name = "Ayaz Ege" });
        }
    }


    public class Customer
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
