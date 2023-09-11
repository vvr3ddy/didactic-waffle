using System.Web;

namespace NewsApp.ViewModels
{
    public class FullStoryViewModel : BaseViewModel, IQueryAttributable
    {
        private string _articleUrl;
        public string ArticleUrl
        {
            get => _articleUrl;
            set => SetProperty(ref _articleUrl, value);
        }
        public FullStoryViewModel()
        {
            Application.Current.MainPage.DisplayAlert("URL", ArticleUrl, "OK");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            ArticleUrl = HttpUtility.UrlDecode(query["articleUrl"].ToString());
        }
    }
}

