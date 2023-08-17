using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using NextMusic.Services;
using Xamarin.Forms;

namespace NextMusic.ViewModels
{
	public class MusicFilesListViewModel: BaseViewModel
	{
		private IFileAccessService _fileAccessService;

		public ObservableCollection<string> MusicFiles { get; set; }
		public ICommand LoadMusicCommand { get; }

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
			_fileAccessService = DependencyService.Get<IFileAccessService>();
			LoadMusicCommand = new Command(async () => await LoadMusicAsync());
		}

		private async Task LoadMusicAsync()
		{
			try
			{
				IsBusy = true;
				MusicFiles.Clear();

				var musicFiles = await _fileAccessService.GetMusicFilesAsync();
				MusicFiles = new ObservableCollection<string>(musicFiles.ToList());
			}catch(Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}

