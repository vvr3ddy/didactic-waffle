using NewsApp.ViewModels;

namespace NewsApp.Views;

public partial class FullStoryPage : ContentPage
{
	
	public FullStoryPage()
	{
		InitializeComponent();
        BindingContext = new FullStoryViewModel();
    }
	
}
