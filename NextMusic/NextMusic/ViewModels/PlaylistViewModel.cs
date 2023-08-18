using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NextMusic.Models;
using NextMusic.Services;
using Xamarin.Forms;

namespace NextMusic.ViewModels
{
	public class PlaylistViewModel: BaseViewModel
	{
		private ObservableCollection<Song> _songs;
		public ObservableCollection<Song> Songs
		{
			get => _songs;
			set
			{
				_songs = value;
				OnPropertyChanged(nameof(Songs));
			}
		}
		private IFilePickerService _filePickerService;
		public ICommand FetchSongs { get; private set; }
		public PlaylistViewModel()
		{
			_filePickerService = new FilePickerService();
            FetchSongs = new Command(async () => await ExecuteFetchSongsCommand());
		}

        private async Task ExecuteFetchSongsCommand()
		{
			var selectedSongs = await _filePickerService.PickAudioFilesAsync();
			
		}
    }
}

