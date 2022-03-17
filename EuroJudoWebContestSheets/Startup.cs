using EuroJudoWebContestSheets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EuroJudoWebContestSheets.Hubs;
using Microsoft.AspNetCore.HttpOverrides;
using System;
using StackExchange.Redis;
using EuroJudoWebContestSheets.Cache;

namespace EuroJudoWebContestSheets
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<dbContext>();

            //services.AddControllers();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            string useRedisValue = Configuration["UseRedis"];
            Console.WriteLine($"UseRedis set to [{useRedisValue}].");

            if (bool.TryParse(useRedisValue, out bool useRedis) && useRedis)
            {
                string redisHost = Configuration["RedisHost"] ?? throw new InvalidOperationException("Missing required configuration parameter [RedisHost].");
                var redisMultiplexer = ConnectionMultiplexer.Connect(redisHost);
                services.AddSingleton<IConnectionMultiplexer>(redisMultiplexer);
                services.AddScoped<ICacheHelper, RedisCacheHelper>();
                Console.WriteLine($"Use [Redis] for caching.");

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
                services.AddMemoryCache();
                services.AddScoped<ICacheHelper, MemoryCacheHelper>();
                Console.WriteLine($"Use [IMemoryCache] for caching.");

                services.AddSignalR(hubOptions =>
                {
                    hubOptions.EnableDetailedErrors = true;
                    hubOptions.KeepAliveInterval = TimeSpan.FromSeconds(3);
                }
                );
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=ContestOrder}/{action=Index}");

                    endpoints.MapControllers();
                    endpoints.MapRazorPages();
                    endpoints.MapHub<TournamentHub>("/tournamentHub");
                    endpoints.MapHub<ContestOrderHub>("/contestOrderHub");
                }
            );
        }
    }
}
