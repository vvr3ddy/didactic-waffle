using System;
using Newtonsoft.Json;

namespace NewsApp.Models
{
	public class NewsItem
	{
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Article
        {
            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("author")]
            public string Author { get; set; }

            [JsonProperty("source")]
            public Source Source { get; set; }

            [JsonProperty("publishedAt")]
            public DateTime PublishedAt { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }
        }

        public class Root
        {
            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("totalResults")]
            public int TotalResults { get; set; }

            [JsonProperty("articles")]
            public List<Article> Articles { get; set; }
        }

        public class Source
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }




    }
}

