using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace api.dataaccess.CacheServices
{

    public class RedisCacheProvider : ICacheProvider
    {
        private readonly TimeSpan? _defaultTtl = TimeSpan.FromMinutes(10);
        private static readonly ConcurrentDictionary<string, object> ConcurrentDictionary = new ConcurrentDictionary<string, object>();
        private readonly IDatabase _cache;
        public RedisCacheProvider(IRedisCacheConnector redisCacheConnector)
        {
            _cache = redisCacheConnector.Connection().GetDatabase();
        }


        public void Add<T>(string key, T item)
        {
            Add(key, item, _defaultTtl);
        }

        public void Add<T>(string key, T item, TimeSpan? timeToLive)
        {
            var cacheItem = JsonConvert.SerializeObject(item);
            var lockOn = ConcurrentDictionary.GetOrAdd(key, new object());

            lock (lockOn)
            {
                _cache.StringSet(
                        key,
                        cacheItem,
                        timeToLive,
                        When.Always,
                        CommandFlags.FireAndForget);


            }
        }

        public T Get<T>(string key, Func<T> dataRetriever) where T : class
        {
            return Get(key, dataRetriever, _defaultTtl);
        }

        public T Get<T>(string key, Func<T> dataRetriever, TimeSpan? timeToLive) where T : class
        {
            var cacheException = false;
            try
            {
                var cachedItem = _cache.StringGet(key);
                if (!cachedItem.IsNullOrEmpty)
                    return JsonConvert.DeserializeObject<T>(cachedItem);
            }
            catch (JsonSerializationException)
            {
                cacheException = true;
            }

            if (cacheException) return null;
            T item = null;
            try
            {
                item = dataRetriever.Invoke();

                // Avoid caching a null value.
                if (item != null)
                {
                    Add(key, item, timeToLive);
                    return item;
                }
            }
            catch (JsonSerializationException)
            {
                // If there is a cache related issue, ignore it and just return the entity.
            }

            return item;
        }

        public object Get(string key, Type type, Func<object> dataRetriever)
        {
            return Get(key, type, dataRetriever, _defaultTtl);
        }

        public object Get(string key, Type type, Func<object> dataRetriever, TimeSpan? timeToLive)
        {

            var cacheException = false;
            try
            {
                var cachedItem = _cache.StringGet(key);
                if (!cachedItem.IsNull)
                    return JsonConvert.DeserializeObject(cachedItem, type);
            }
            catch (JsonSerializationException)
            {
                cacheException = true;
            }

            if (cacheException) return null;
            object item = null;
            try
            {
                item = dataRetriever.Invoke();

                // Avoid caching a null value.
                if (item != null && item.GetType() == type)
                {
                    Add(key, item, timeToLive);
                    return item;
                }
            }
            catch (JsonSerializationException)
            {

            }

            return item;
        }

        public Task<T> GetAsync<T>(string key, Func<Task<T>> dataRetriever) where T : class
        {
            return GetAsync(key, dataRetriever, _defaultTtl);
        }

        public async Task<T> GetAsync<T>(string key, Func<Task<T>> dataRetriever, TimeSpan? timeToLive) where T : class
        {
            var cacheException = false;
            try
            {
                var cachedItem = await _cache.StringGetAsync(key);
                if (!cachedItem.IsNull)
                    return JsonConvert.DeserializeObject<T>(cachedItem);
            }
            catch (JsonSerializationException)
            {
                cacheException = true;
            }

            if (cacheException) return null;
            try
            {
                var item = await dataRetriever.Invoke();

                // Avoid caching a null value.
                if (item != null)
                {
                    Add(key, item, timeToLive);
                    return item;
                }
            }
            catch (JsonSerializationException)
            {

            }

            return null;
        }

        public Task<object> GetAsync(string key, Type type, Func<Task<object>> dataRetriever)
        {
            return GetAsync(key, type, dataRetriever, _defaultTtl);
        }

        public async Task<object> GetAsync(string key, Type type, Func<Task<object>> dataRetriever, TimeSpan? timeToLive)
        {
            var cachedItem = await _cache.StringGetAsync(key);
            if (!cachedItem.IsNull)
                return JsonConvert.DeserializeObject(cachedItem, type);

            var item = await dataRetriever.Invoke();
            if (item != null && item.GetType() == type)
            {
                Add(key, item, timeToLive);
                return item;
            }

            return null;
        }

        public bool Invalidate(string key)
        {
            return _cache.KeyDelete(key, CommandFlags.FireAndForget);
        }

        public async Task<bool> InvalidateAll()
        {
            await Task.Run(() =>
            {
                foreach (var keyValuePair in ConcurrentDictionary)
                {
                    Invalidate(keyValuePair.Key);
                }
            });

            return true;
        }

        public TimeSpan? DefaultTtl => _defaultTtl;
    }
}
