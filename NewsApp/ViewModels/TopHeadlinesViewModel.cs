using System;
using System.Windows.Input;

namespace NewsApp.ViewModels
{
    public class TopHeadlinesViewModel : BaseViewModel
    {
        private bool _isBannerVisible;
        private bool _hasContentLoaded;
        private string _loadRefreshNews;

        public bool IsBannerVisible
        {
            get => _isBannerVisible;
            set => SetProperty(ref _isBannerVisible, value);
        }

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
        public ICommand DismissBannerCommand { get; }
        public ICommand AllowNotificationsCommand { get; }

        public TopHeadlinesViewModel()
        {
            IsBannerVisible = true; // Banner is visible by default
            HasContentLoaded = false;
            LoadRefreshNews = "Load News";

            LoadNewsArticlesCommand = new Command(LoadArticles);
            DismissBannerCommand = new Command(DismissBanner);
            AllowNotificationsCommand = new Command(AllowNotifications);
        }

        private void LoadArticles()
        {
            // Your existing logic for loading articles
            HasContentLoaded = true;
            LoadRefreshNews = "Refresh News";
        }

        private void DismissBanner()
        {
            IsBannerVisible = false; // This will hide the banner
        }

        private void AllowNotifications()
        {
            // Your logic to allow notifications
            IsBannerVisible = false; // This will also hide the banner
        }
    }
}

