using System;
using System.Windows.Input;

namespace NewsApp.ViewModels
{
	public class TopHeadlinesViewModel: BaseViewModel
	{
        private bool _hasContentLoaded;
        private string _loadRefreshNews;
        public bool HasContentLoaded
        {
            get => _hasContentLoaded;
            set => SetProperty(ref _hasContentLoaded, value);
        }
        public string LoadRefreshNews
        {
            get => _loadRefreshNews;
            set => SetProperty(ref _loadRefreshNews, value);
        }

        public ICommand LoadNewsArticlesCommand { get; }

        public TopHeadlinesViewModel()
		{
            HasContentLoaded = false;
            LoadRefreshNews = "Load News";
            LoadNewsArticlesCommand = new Command(LoadArticles);

        }

        protected void LoadArticles()
        {
            HasContentLoaded = true;
            LoadRefreshNews = "Refresh News";
        }
	}
}

