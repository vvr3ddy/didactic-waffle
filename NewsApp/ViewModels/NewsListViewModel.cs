using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Messaging;
using NewsApp.Messages;
using NewsApp.Models;
using NewsApp.Services;
using NewsApp.Views;

namespace NewsApp.ViewModels
{
    public class NewsListViewModel : BaseViewModel
    {
        private ObservableCollection<NewsItem.Article> _newsArticles;
        private readonly INewsAPIService _newsAPIService;
        public ObservableCollection<NewsItem.Article> NewsArticles
        {
            get => _newsArticles;
            set
            {
                SetProperty(ref _newsArticles, value);
            }
        }

        public ICommand ReadStoryCommand { get; }
        public ICommand LoadNewsArticlesCommand { get; }
        public NewsListViewModel()
        {
            _newsAPIService = NewsAPIService.Instance;

            ReadStoryCommand = new Command<string>(async (url) => await ReadStory(url));
            LoadArticlesAsync();

            
        }

        protected async Task LoadArticlesAsync()
        {
            NewsItem.Root news = await _newsAPIService.GetNewsItemAsync();
            //NewsArticles = new ObservableCollection<NewsItem.Article>(news.Articles);
            string messageItem = string.Empty;
            WeakReferenceMessenger.Default.Register<UpdateNewsListMessage>(this, (recipient, message) =>
            {
                NewsArticles = new ObservableCollection<NewsItem.Article>(message.NewsArticles);
                messageItem = message.Source;
            });
            await Application.Current.MainPage.DisplayAlert("Receiver", messageItem, "OK");
        }

        protected async Task ReadStory(string url)
        {
            DisplayToast("Implementation Pending", ToastDuration.Long);
            await Shell.Current.GoToAsync($"{nameof(FullStoryPage)}?articleUrl={url}");
        }

        protected async static void DisplayToast(string toastMessage, ToastDuration duration)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            double fontSize = 14;

            var toast = Toast.Make(toastMessage, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
    }
}

