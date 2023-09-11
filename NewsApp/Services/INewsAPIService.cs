using System;
using NewsApp.Models;

namespace NewsApp.Services
{
	public interface INewsAPIService
	{
		Task<NewsItem.Root> GetNewsItemAsync();
		Task<NewsItem.Root> GetNewsBasedOnSearch(string query);
	}
}

