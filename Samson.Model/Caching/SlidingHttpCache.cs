using System;
using System.Web;
using System.Web.Caching;

namespace Samson.Model.Caching
{
    public class SlidingHttpCache : HttpCacheBase
    {
        private readonly int _expirationMinutes;

        protected override string AddedCacheItemsKey { get { return "SlidingCache.AddedKeys"; } }

        public SlidingHttpCache()
        {
            _expirationMinutes = 120;
        }

        public SlidingHttpCache(int expirationMinutes)
        {
            _expirationMinutes = expirationMinutes;
        }

        public override void Add(string key, object value, int? cacheMinutes = null)
        {
            var mins = cacheMinutes.HasValue && cacheMinutes.Value > 0 ? cacheMinutes : _expirationMinutes;

            var timespan = new TimeSpan(0,0,mins.Value,0,0);

            HttpContext.Current.Cache.Insert(key, value, null, Cache.NoAbsoluteExpiration, timespan);
            AddNewKeyToAddedKeys(key);
        }
    }
}