using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Application.Interfaces.Services.Scraper;
using WebMVC.Application.Interfaces.Services.Stopword;
using WebMVC.Infrastructure.Services.Scraper;
using WebMVC.Infrastructure.Services.Stopword;

namespace WebMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiHttpClients(configuration);

            return services;
        }

        public static IServiceCollection AddApiHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IScraperService, ScraperService>(client =>
            {
                client.BaseAddress = new Uri(configuration["Apis:WebScraper"]);
            });
            services.AddHttpClient<IStopwordService, StopwordService>(client =>
            {
                client.BaseAddress = new Uri(configuration["Apis:WebScraper"]);
            });

            return services;
        }
    }
}
