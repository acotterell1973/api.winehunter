using System;
using System.Linq;
using StackExchange.Redis;

namespace api.dataaccess.CacheServices
{
    public class RedisCacheConnector : IRedisCacheConnector
    {
        private static readonly Lazy<ConfigurationOptions> ConfigOptions = new Lazy<ConfigurationOptions>(() =>
        {
            const string customSetting = "tas.redis.Cache.windows.net,abortConnect=false,ssl=true,password=Pc6zcZkcDQDm6f2G7D2yHiWf0unY3JSDtTFpCRJ8jhQ=";
            var redisConnection = customSetting.Split(',');
            var configOptions = new ConfigurationOptions
            {
                ConnectTimeout = 100000,
                SyncTimeout = 100000,
                ClientName = "asap.web.api",
                Ssl = true,
                AbortOnConnectFail = false,
                Password = redisConnection.Last().Replace("password=", string.Empty)

            };
            configOptions.EndPoints.Add(redisConnection.First());
            return configOptions;
        });
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection =
            new Lazy<ConnectionMultiplexer>(
                () => ConnectionMultiplexer.Connect(ConfigOptions.Value));

        ConnectionMultiplexer IRedisCacheConnector.Connection()
        {
            return LazyConnection.Value;
        }
    }
}
