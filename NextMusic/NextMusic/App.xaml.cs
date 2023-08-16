using System;
using NextMusic.Views;
using Xamarin.Forms;

namespace NextMusic
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();
            MainPage = new MusicPlayerPage();
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

