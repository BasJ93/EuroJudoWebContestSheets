using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace EuroJudoWebContestSheets.Configuration;

public static class Caching
{
    public static IServiceCollection AddCaching(this IServiceCollection services, IConfiguration configuration)
    {
        string useRedisValue = configuration["UseRedis"];
        Console.WriteLine($"UseRedis set to [{useRedisValue}].");

        if(bool.TryParse(useRedisValue, out bool useRedis) && useRedis)
        {
            string redisHost = configuration["RedisHost"] ?? throw new InvalidConfigurationException("Missing required configuration parameter [RedisHost].");
            var redisMultiplexer = ConnectionMultiplexer.Connect(redisHost);
            services.AddSingleton<IConnectionMultiplexer>(redisMultiplexer);
            Console.WriteLine($"Use [Redis] for caching.");

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisHost;
                options.InstanceName = "EJUWebDistributedCache";
            });
                
            services.AddSignalR(hubOptions =>
                {
                    hubOptions.EnableDetailedErrors = true;
                    hubOptions.KeepAliveInterval = TimeSpan.FromSeconds(3);
                }
            ).AddStackExchangeRedis(redisHost, options => 
            {
                options.Configuration.ChannelPrefix = "SignalR";
            });
        }
        else
        {
            services.AddDistributedMemoryCache();
            Console.WriteLine($"Use [IMemoryCache] for caching.");

            services.AddSignalR(hubOptions =>
                {
                    hubOptions.EnableDetailedErrors = true;
                    hubOptions.KeepAliveInterval = TimeSpan.FromSeconds(3);
                }
            );
        }

        return services;
    }
}