using NewsApp.Views;

namespace NewsApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		//Navigation Pages
		Routing.RegisterRoute(nameof(FullStoryPage), typeof(FullStoryPage));
	}
}

