using Xamarin.Forms;

namespace NextMusic
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();
            // Not updating MainPage = new AppShell(); will lead to an exception:
            // 'Object reference not set to an instance of an object'
            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

