using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using NewsApp.Messages;
using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.ViewModels
{
    public class SearchNewsViewModel : BaseViewModel
    {
        private ObservableCollection<NewsItem.Article> _filteredArticles;
        private INewsAPIService _newsAPIService;
        public ObservableCollection<NewsItem.Article> FilteredArticles
        {
            get => _filteredArticles;
            set => SetProperty(ref _filteredArticles, value);
        }

        public ICommand SearchCommand { get; private set; }

        public SearchNewsViewModel()
        {
            FilteredArticles = new ObservableCollection<NewsItem.Article>();
            _newsAPIService = NewsAPIService.Instance;
            SearchCommand = new Command<string>(async (text) => await SearchNewsArticles(text));
        }

        public async Task SearchNewsArticles(string query)
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {
                FilteredArticles.Clear();
                NewsItem.Root newsArticles = !string.IsNullOrEmpty(query) ? await _newsAPIService.GetNewsBasedOnSearch(query): new NewsItem.Root();
                FilteredArticles = new ObservableCollection<NewsItem.Article>(newsArticles.Articles);
                WeakReferenceMessenger.Default.Send(new UpdateNewsListMessage(FilteredArticles,"FilteredArticles"));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"{ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

