using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebScraper.API.Common.Filters;
using WebScraper.API.Common.Options;
using WebScraper.API.Data;
using WebScraper.API.Interfaces.Scraper;
using WebScraper.API.Interfaces.Stopwords;
using WebScraper.API.Repositories.Cache;
using WebScraper.API.Repositories.Stopwords;
using WebScraper.API.Services.Scraper;

namespace WebScraper.API
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

            services.AddControllers(options => {
                options.Filters.Add<ApiExceptionFilterAttribute>();
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebScraper.API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //configure redis cache
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration["CacheSettings:ConnectionString"];
                options.InstanceName = "WebScraper.API.";
            });

            //configure options pattern
            services.Configure<DatabaseSettingOptions>(Configuration.GetSection(DatabaseSettingOptions.DatabaseSettings));
            services.Configure<CacheSettingOptions>(Configuration.GetSection(CacheSettingOptions.CacheSettings));

            //dependency injection of services
            services.AddSingleton<IStopwordContext, StopwordContext>();
            services.AddScoped<ITextScraperService, TextScraperService>();
            services.AddScoped<IStopwordsRepository, StopwordsRepository>();
            services.AddScoped<ICacheUrlDataRepository, CacheUrlDataRepository>();

            //HttpClients
            services.AddHttpClient<ILinkScraperService, LinkScraperService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebScraper.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
