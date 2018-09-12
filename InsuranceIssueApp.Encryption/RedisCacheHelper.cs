using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using StackExchange.Redis;
using Newtonsoft.Json;
using System.Configuration;

namespace InsuranceIssueApp.Common
{
    public static class RedisCacheHelper
    {

        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string cacheConnection = ConfigurationManager.AppSettings["CacheConnection"].ToString();
            return ConnectionMultiplexer.Connect(cacheConnection);
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }

        public static bool addItemCache<T>(string keyname, List<T> obj)
        {
            IDatabase cache = lazyConnection.Value.GetDatabase();          
            cache.StringSet(keyname, JsonConvert.SerializeObject(obj));
            return true;
        }

        public static bool keyExistsInCache(string keyname)
        {
            IDatabase cache = lazyConnection.Value.GetDatabase();
            return cache.KeyExists(keyname);
        }

        public static List<T> GetCacheData<T>(string keyname)
        {
            IDatabase cache = lazyConnection.Value.GetDatabase();
            List<T> obj = JsonConvert.DeserializeObject<List<T>>(cache.StringGet(keyname));
            return obj;
        }

        public static bool RemoveCacheData(string keyname)
        {
            IDatabase cache = lazyConnection.Value.GetDatabase();
            if (cache.KeyExists(keyname))
            {
                cache.KeyDelete(keyname);
            }
            return true;
        }
    }
}
