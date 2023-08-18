using System;
using System.Threading.Tasks;
using System.Windows.Input;
using NextMusic.Models;
using NextMusic.Services;
using Xamarin.Forms;

namespace NextMusic.ViewModels
{
    public class PlayerViewModel : BaseViewModel
    {

        private readonly IMusicPlayerService _musicPlayerService;

        private Song _currentSong;
        private bool _isPlaying;

        public ICommand PlayPauseCommand { get; private set; }
        public ICommand NextCommand { get; private set; }
        public ICommand PreviousCommand { get; private set; }
        public ICommand SeekCommand { get; private set; }
        public ICommand PopulatePlaylistCommand { get; private set; }

        public Song CurrentSong
        {
            get => _currentSong;
            set
            {
                _currentSong = value;
                OnPropertyChanged(nameof(CurrentSong));
            }
        }

        public bool IsPlaying
        {
            get => _isPlaying;
            set
            {
                _isPlaying = value;
                OnPropertyChanged(nameof(IsPlaying));
                OnPropertyChanged(nameof(PlayPauseIcon));
            }
        }
        public string PlayPauseIcon => IsPlaying ? "⏸︎" : "⏵︎";
        //private string _playPauseIcon;
        //public string PlayPauseIcon
        //{
        //    get => _playPauseIcon;
        //    set
        //    {
        //        _playPauseIcon = value;
        //        OnPropertyChanged(nameof(PlayPauseIcon));
        //    }
        //}

        public PlayerViewModel()
        {

            _musicPlayerService = DependencyService.Get<IMusicPlayerService>();
            _musicPlayerService.OnSongChanged += song => CurrentSong = song;


            PlayPauseCommand = new Command(ExecutePlayPause);
            NextCommand = new Command(ExecuteNext);
            PreviousCommand = new Command(ExecutePrevious);
            //SeekCommand = new Command<double>(ExecuteSeek);

        }

        private void ExecutePlayPause()
        {
            
            if (IsPlaying)
            {
                _musicPlayerService.Pause();
                //PlayPauseIcon = "►";
                IsPlaying = false;
            }
            else
            {
                if (CurrentSong != null)
                {
                    _musicPlayerService.Play(CurrentSong);
                }
                else
                {
                    // Maybe play the first song in the playlist
                }
                IsPlaying = true;
                //PlayPauseIcon = "⏸";
            }
        }

        private void ExecuteNext()
        {
            _musicPlayerService.Next();
            IsPlaying = true;
        }

        private void ExecutePrevious()
        {
            _musicPlayerService.Previous();
            IsPlaying = true;
        }

        

    }
}

