using System;
using System.Linq;
using StackExchange.Redis;

namespace api.dataaccess.CacheServices
{
    public class RedisCacheConnector : IRedisCacheConnector
    {
        private static readonly Lazy<ConfigurationOptions> ConfigOptions = new Lazy<ConfigurationOptions>(() =>
        {
            const string customSetting = "wine-hunter.redis.cache.windows.net:6380,ssl=True,abortConnect=False,password=bjjbKt5WuT27eRP/7gSLq8RbScKZnJo3VC2bWadsPSo=";
            var redisConnection = customSetting.Split(',');
            var configOptions = new ConfigurationOptions
            {
                ConnectTimeout = 100000,
                SyncTimeout = 100000,
                ClientName = "api.winehunter",
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
