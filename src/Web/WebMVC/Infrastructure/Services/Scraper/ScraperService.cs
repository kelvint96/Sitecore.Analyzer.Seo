using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebMVC.Application.Interfaces.Services.Scraper;
using WebMVC.Application.Services.Scraper.Models.Response;

namespace WebMVC.Infrastructure.Services.Scraper
{
    public class ScraperService : IScraperService
    {
        private readonly HttpClient _httpClient;

        public ScraperService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BodyData> GetBodyData(string text, string scrapeType)
        {
            var json = new StringContent(JsonSerializer.Serialize(new { text = text ?? string.Empty }), Encoding.UTF8, "application/json");
            using var httpResponse = await _httpClient.PostAsync($"/api/Scrape/{scrapeType.First().ToString().ToUpper() + scrapeType.Substring(1)}/Body", json);

            httpResponse.EnsureSuccessStatusCode();

            using var responseStream = await httpResponse.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <BodyData>(responseStream);
        }

        public async Task<LinkData> GetLinkData(string text, string scrapeType)
        {
            var json = new StringContent(JsonSerializer.Serialize(new { text = text ?? string.Empty }), Encoding.UTF8, "application/json");
            using var httpResponse = await _httpClient.PostAsync($"/api/Scrape/{scrapeType.First().ToString().ToUpper() + scrapeType.Substring(1)}/Link", json);

            httpResponse.EnsureSuccessStatusCode();

            using var responseStream = await httpResponse.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <LinkData>(responseStream);
        }

        public async Task<MetaData> GetMetaData(string text, string scrapeType)
        {
            var json = new StringContent(JsonSerializer.Serialize(new { text = text ?? string.Empty }), Encoding.UTF8, "application/json");
            using var httpResponse = await _httpClient.PostAsync($"/api/Scrape/{scrapeType.First().ToString().ToUpper() + scrapeType.Substring(1)}/Meta", json);

            httpResponse.EnsureSuccessStatusCode();

            using var responseStream = await httpResponse.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <MetaData>(responseStream);
        }

    }
}
