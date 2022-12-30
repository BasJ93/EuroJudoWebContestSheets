using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EuroJudoWebContestSheets.Hubs;
using Microsoft.AspNetCore.HttpOverrides;
using EuroJudoWebContestSheets.Configuration;
using EuroJudoWebContestSheets.Database;
using Microsoft.EntityFrameworkCore;
using NSwag;

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

            services.AddDatabase();

            services.AddServiceLayers();
            
            services.AddControllersWithViews();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            
            services.ConfigureAuthentication();

            services.AddCaching(Configuration);

            services.AddOpenApiDocument(document =>
            {
                document.AddSecurity("apikey", Enumerable.Empty<string>(), new OpenApiSecurityScheme()
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "x-api-key",
                    In = OpenApiSecurityApiKeyLocation.Header
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ContestSheetDbContext dbContext)
        {

            List<string> pendingMigrations = dbContext.Database.GetPendingMigrations().ToList();

            if (pendingMigrations.Any())
            {
                foreach (string pendingMigration in pendingMigrations)
                {
                    Console.WriteLine($"Pending migration: [{pendingMigration}]", pendingMigration);
                }
                
                dbContext.Database.Migrate();                
            }
            
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

            app.UseOpenApi();
            app.UseSwaggerUi3();
            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=ContestOrder}/{action=Index}");

                    endpoints.MapControllers();
                    
                    endpoints.MapHub<TournamentHub>("/tournamentHub");
                    endpoints.MapHub<ContestOrderHub>("/contestOrderHub");
                }
            );
        }
    }
}
