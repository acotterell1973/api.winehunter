using StackExchange.Redis;

namespace api.dataaccess.CacheServices
{
    public interface IRedisCacheConnector
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ConnectionMultiplexer Connection();
    }
}
