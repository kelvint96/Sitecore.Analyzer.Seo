using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebMVC.Application.Interfaces.Services.Stopword;
using StopwordModel = WebMVC.Application.Services.Stopword.Models.Response.Stopword;

namespace WebMVC.Infrastructure.Services.Stopword
{
    public class StopwordService : IStopwordService
    {
        private readonly HttpClient _httpClient;
        public StopwordService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateStopword(StopwordModel stopword)
        {
            var stopwordJson = new StringContent(JsonSerializer.Serialize(stopword), Encoding.UTF8, "application/json");
            using var httpResponse = await _httpClient.PostAsync($"/api/Stopwords", stopwordJson);

            httpResponse.EnsureSuccessStatusCode();
        }

        public async Task DeleteStopword(string id)
        {
            using var httpResponse = await _httpClient.DeleteAsync($"/api/Stopwords/{id}");
            httpResponse.EnsureSuccessStatusCode();
        }

        public async Task<StopwordModel> GetStopwordById(string id)
        {
            using var httpResponse = await _httpClient.GetAsync($"/api/Stopwords/{id}");

            if (httpResponse.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return null;
            }
            else
            {
                using var responseStream = await httpResponse.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync
                    <StopwordModel>(responseStream);
            }

        }

        public async Task<List<StopwordModel>> GetStopwords()
        {
            using var httpResponse = await _httpClient.GetAsync($"/api/Stopwords");
            httpResponse.EnsureSuccessStatusCode();

            using var responseStream = await httpResponse.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <List<StopwordModel>>(responseStream);
        }

        public async Task UpdateStopword(StopwordModel stopword)
        {
            var stopwordJson = new StringContent(JsonSerializer.Serialize(stopword), Encoding.UTF8, "application/json");
            using var httpResponse = await _httpClient.PutAsync($"/api/Stopwords/{stopword.Id}", stopwordJson);

            httpResponse.EnsureSuccessStatusCode();
        }
    }
}
