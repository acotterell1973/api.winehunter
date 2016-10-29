using System;
using System.Threading.Tasks;

namespace api.dataaccess.CacheServices
{
    public interface ICacheProvider  
    {
        void Add<T>(string key, T item);
        void Add<T>(string key, T item, TimeSpan? timeToLive);

        T Get<T>(string key, Func<T> dataRetriever) where T : class;
        T Get<T>(string key, Func<T> dataRetriever, TimeSpan? timeToLive) where T : class;

        object Get(string key, Type type, Func<object> dataRetriever);
        object Get(string key, Type type, Func<object> dataRetriever, TimeSpan? timeToLive);

        Task<T> GetAsync<T>(string key, Func<Task<T>> dataRetriever) where T : class;
        Task<T> GetAsync<T>(string key, Func<Task<T>> dataRetriever, TimeSpan? timeToLive) where T : class;

        Task<object> GetAsync(string key, Type type, Func<Task<object>> dataRetriever);
        Task<object> GetAsync(string key, Type type, Func<Task<object>> dataRetriever, TimeSpan? timeToLive);

        bool Invalidate(string key);

        Task<bool> InvalidateAll();

        TimeSpan? DefaultTtl { get; }
    }
}
