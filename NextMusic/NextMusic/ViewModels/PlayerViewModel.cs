using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace NextMusic.ViewModels
{
    public class PlayerViewModel : BaseViewModel
	{
        public ICommand PlayPauseCommand { get; private set; }
        public ICommand NextCommand { get; private set; }
        public ICommand PreviousCommand { get; private set; }

        public PlayerViewModel()
        {
            PlayPauseCommand = new Command(ExecutePlayPause);
            NextCommand = new Command(ExecuteNext);
            PreviousCommand = new Command(ExecutePrevious);
        }

        private void ExecutePlayPause()
        {
            // Logic for playing or pausing the song
        }

        private void ExecuteNext()
        {
            // Logic for moving to the next song
        }

        private void ExecutePrevious()
        {
            // Logic for moving to the previous song
        }
    }
}

