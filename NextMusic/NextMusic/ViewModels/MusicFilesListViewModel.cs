using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using NextMusic.Services;
using NextMusic.Views;
using Xamarin.Forms;

namespace NextMusic.ViewModels
{
	public class MusicFilesListViewModel: BaseViewModel
	{
		public ObservableCollection<string> MusicFiles { get; set; }
		public ICommand SelectSongCommand { get; }

		private bool _isBusy;
        public bool IsBusy {
			get => _isBusy; 
			private set
			{
				_isBusy = SetProperty(ref _isBusy, value);
				OnPropertyChanged(nameof(IsBusy));
			}
		}

        public MusicFilesListViewModel()
		{
		
			MusicFiles = new ObservableCollection<string>();
			LoadMusicAsync();

			SelectSongCommand = new Command<string>(async (selectedSong) => await SelectSongAsync(selectedSong));
		}

		private async void LoadMusicAsync()
		{
			try
			{
				IsBusy = true;
				//TODO: Implement the Music file loading properly
				
			}catch(Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
			finally
			{
				IsBusy = false;
			}
		}

		private async Task SelectSongAsync(string selectedSong)
		{
			try
			{
				IsBusy = true;
				var remainingSongs = MusicFiles.SkipWhile(song => song != selectedSong).ToList();

				await Shell.Current.GoToAsync($"//{nameof(MusicPlayerPage)}?" +
					$"selectedSong={selectedSong}" +
					$"&remainingSongs={Uri.EscapeDataString(JsonConvert.SerializeObject(remainingSongs))}");
			}catch(Exception ex)
			{
				Console.WriteLine($"Error:{ex.Message}");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}

