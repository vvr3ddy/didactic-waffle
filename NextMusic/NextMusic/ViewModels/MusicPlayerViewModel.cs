using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace NextMusic.ViewModels
{
    public class MusicPlayerViewModel : BaseViewModel
    {
        private bool _isPlaying;

        public bool IsPlaying
        {
            get => _isPlaying;
            set => SetProperty(ref _isPlaying, value);
        }

        public ICommand TogglePlayCommand { get; }

        public MusicPlayerViewModel()
        {
            TogglePlayCommand = new Command(TogglePlay);
        }

        private void TogglePlay()
        {
            IsPlaying = !IsPlaying;
        }
    }
}

