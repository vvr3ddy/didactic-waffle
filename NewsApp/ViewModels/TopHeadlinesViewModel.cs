using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using NewsApp.Messages;
using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.ViewModels
{
    public class TopHeadlinesViewModel : BaseViewModel
    {
        private bool _isBannerVisible;
        private bool _hasContentLoaded;
        private string _loadRefreshNews;
        private INewsAPIService _newsAPIService;

        private ObservableCollection<NewsItem.Article> _newsArticles;

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

        public ObservableCollection<NewsItem.Article> NewsArticles
        {
            get => _newsArticles;
            set => SetProperty(ref _newsArticles, value);
        }

        public ICommand LoadNewsArticlesCommand { get; }
        public ICommand DismissBannerCommand { get; }
        public ICommand AllowNotificationsCommand { get; }

        public TopHeadlinesViewModel()
        {
            IsBannerVisible = true; // Banner is visible by default
            HasContentLoaded = false;
            LoadRefreshNews = "Load News";
            _newsAPIService = NewsAPIService.Instance;
            NewsArticles = new ObservableCollection<NewsItem.Article>();


            LoadNewsArticlesCommand = new Command(async () => await LoadArticles());
            DismissBannerCommand = new Command(DismissBanner);
            AllowNotificationsCommand = new Command(AllowNotifications);
        }

        private async Task LoadArticles()
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {
                NewsArticles.Clear();
                NewsItem.Root newsContent = await _newsAPIService.GetNewsItemAsync();
                NewsArticles = new ObservableCollection<NewsItem.Article>(newsContent.Articles);
                WeakReferenceMessenger.Default.Send(new UpdateNewsListMessage(NewsArticles, "TopHeadlines"));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"{ex.Message}", "OK");
            }
            finally
            {
                HasContentLoaded = true;
                LoadRefreshNews = "Refresh News";
                IsBusy = false;
            }
            
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

