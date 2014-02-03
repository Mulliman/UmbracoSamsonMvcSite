using System;
using System.Web;
using System.Web.Caching;

namespace Samson.Model.Caching
{
    public class HttpCache : ICache
    {
        private readonly int _expirationMinutes;

        public HttpCache()
        {
            _expirationMinutes = 120;
        }

        public HttpCache(int expirationMinutes)
        {
            _expirationMinutes = expirationMinutes;
        }

        public void Add(string key, object value, int? cacheMinutes = null)
        {
            var mins = cacheMinutes.HasValue && cacheMinutes.Value > 0 ? cacheMinutes : _expirationMinutes;

            var expireDate = DateTime.Now.AddMinutes(mins.Value);

            HttpContext.Current.Cache.Insert(key, value, null, expireDate, Cache.NoSlidingExpiration);
        }

        public void Remove(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        public object Retrieve(string key)
        {
            return HttpContext.Current.Cache[key];
        }

        public T Retrieve<T>(string key) where T : class
        {
            return HttpContext.Current.Cache[key] as T;
        }

        public bool Contains(string key)
        {
            return HttpContext.Current.Cache[key] != null;
        }
    }
}