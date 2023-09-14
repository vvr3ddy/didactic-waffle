using System;
using System.Collections.ObjectModel;
using NewsApp.Models;

namespace NewsApp.Messages
{
	public record UpdateNewsListMessage(ObservableCollection<NewsItem.Article> NewsArticles, string Source);
	
}

