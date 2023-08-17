using System;
using System.Windows.Input;
using NextMusic.Models;
using NextMusic.Services;
using Xamarin.Forms;

namespace NextMusic.ViewModels
{
    public class MusicPlayerViewModel : BaseViewModel
    {
        private Song _song;
        public Song Song
        {
            get => _song;
            set
            {
                SetProperty(ref _song, value);
                OnPropertyChanged(nameof(Song));
            }
        }

        private bool _isPlaying;
        public bool IsPlaying
        {
            get => _isPlaying;
            set
            {
                SetProperty(ref _isPlaying, value);
                OnPropertyChanged(nameof(IsPlaying));
            }
        }

        private string _playPauseButtonText;
        public string PlayPauseButtonText
        {
            get => _playPauseButtonText;
            set
            {
                SetProperty(ref _playPauseButtonText,value);
                OnPropertyChanged(nameof(PlayPauseButtonText));
            }
        }



        public ICommand TogglePlayCommand { get; }
        public ICommand LoadPlaylistCommand { get; }
        public MusicPlayerViewModel()
        {
            IsPlaying = false;
            TogglePlayCommand = new Command(TogglePlay);
            LoadPlaylistCommand = new Command(LoadSongsAsync);
        }

        private async void LoadSongsAsync()
        {
            await Shell.Current.GoToAsync("//playlist");
        }

        private void TogglePlay()
        {
            IsPlaying = !IsPlaying;
            PlayPauseButtonText = IsPlaying ? "Pause" : "Play";
        }
    }
}

