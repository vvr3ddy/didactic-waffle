using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Newtonsoft.Json;
using NextMusic.Models;
using NextMusic.Services;
using Xamarin.Forms;

namespace NextMusic.ViewModels
{
    [QueryProperty(nameof(SelectSong), "selectedSong")]
    [QueryProperty(nameof(RemainingSongs), "remainingSongs")]
    public class MusicPlayerViewModel : BaseViewModel
    {
        private Song _selectedSong;
        public Song SelectedSong
        {
            get => _selectedSong;
            set
            {
                SetProperty(ref _selectedSong, value);
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
        //TODO: Delete this once we have proper implementation of song fetching
        private string _selectSong;
        public string SelectSong
        {
            get => _selectSong;
            set
            {
                SetProperty(ref _selectSong, value);
                OnPropertyChanged(nameof(SelectSong));
            }
        }
        //TODO: Update the List once we have propert Song fetching functionality
        private ObservableCollection<string> _remainingSongs;
        public ObservableCollection<string> RemainingSongs
        {
            get => _remainingSongs;
            set
            {
                SetProperty(ref _remainingSongs, value);
                OnPropertyChanged(nameof(RemainingSongs));
            }
        }

        public ICommand TogglePlayCommand { get; }
        public ICommand LoadPlaylistCommand { get; }

        public MusicPlayerViewModel()
        {

            IsPlaying = false;
            // Receive navigation parameters
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

