using Microsoft.Extensions.Caching.Memory;

namespace NencerHis.Extensions
{
    public static class CacheManagerExtension
    {
        private static readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public static void AddToCache(string key, object value, int? durationInMinutes = null)
        {
            if (value == null)
                return;

            var cacheEntryOptions = new MemoryCacheEntryOptions();

            if (durationInMinutes.HasValue)
            {
                cacheEntryOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(durationInMinutes.Value);
            }

            _cache.Set(key, value, cacheEntryOptions);
        }

        public static void AddToCache<T>(string key, T value, TimeSpan? expirationTime)
        {
            if (value == null)
                return;

            var cacheEntryOptions = new MemoryCacheEntryOptions();

            if (expirationTime.HasValue)
            {
                cacheEntryOptions.AbsoluteExpirationRelativeToNow = expirationTime;
            }

            _cache.Set(key, value, cacheEntryOptions);
        }

        public static (bool, T) GetFromCache<T>(string key) where T : class
        {
            var isContaint = _cache.TryGetValue(key, out T value);
            return (isContaint, value);
        }

        public static void RemoveFromCache(string key)
        {
            _cache.Remove(key);
        }

        public static void ClearCache()
        {
            _cache.Clear();
        }
    }
}
