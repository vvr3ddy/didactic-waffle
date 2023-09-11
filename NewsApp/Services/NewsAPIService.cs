using System;
using Newtonsoft.Json;
using NewsApp.Models;

namespace NewsApp.Services
{
    public sealed class NewsAPIService : INewsAPIService
    {
        private static NewsAPIService _newsAPIService;

        public static NewsAPIService Instance => _newsAPIService ??= new NewsAPIService();


        public async Task<NewsItem.Root> GetNewsItemAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client
                    .GetAsync("https://newsapi.org/v2/top-headlines?country=us&apiKey=5a9a20ed78ed400b91551817c6b459e8");
                response.EnsureSuccessStatusCode();
                string responseJson = await response.Content.ReadAsStringAsync();
                var newsItem = JsonConvert.DeserializeObject<NewsItem.Root>(responseJson);
                return newsItem;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error:{ex.Message}");
            }

        }

        public async Task<NewsItem.Root> GetNewsBasedOnSearch(string query)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client
                    .GetAsync($"https://newsapi.org/v2/everything?q={query}&apiKey=5a9a20ed78ed400b91551817c6b459e8");
                response.EnsureSuccessStatusCode();
                string responseJson = await response.Content.ReadAsStringAsync();
                var newsItem = JsonConvert.DeserializeObject<NewsItem.Root>(responseJson);
                return newsItem;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

    }
}

