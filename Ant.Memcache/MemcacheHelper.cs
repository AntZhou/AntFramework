namespace Ant.Memcache
{
    using System;

    using Memcached.Client;

    public class MemcacheHelper
    {
        private const string PoolName = "AntMemcache";

        public static MemcacheHelper Instance = new MemcacheHelper();

        private readonly MemcachedClient client;
 
        private MemcacheHelper()
        {
            var pool = SockIOPool.GetInstance(PoolName);
            pool.SetServers(new string[]{ "10.10.0.61:11211" });
            pool.Initialize();

            this.client = new MemcachedClient() { PoolName = PoolName };
        }

        public void Set(string key, object value)
        {
            this.client.Set(key, value);
        }

        public T Get<T>(string key)
        {
            return (T)this.client.Get(key);
        }


    }
}