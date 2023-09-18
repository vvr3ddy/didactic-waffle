using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NoteKeeper.Models;
using NoteKeeper.Repositories;

namespace NoteKeeper.ViewModels
{
	public class MainViewModel: BaseViewModel
	{

		private ObservableCollection<Note> _existingNotes;
        private NoteRepository _notesRepository;

		public ObservableCollection<Note> ExistingNotes
		{
			get => _existingNotes;
			set => SetProperty(ref _existingNotes, value);
		}
		public bool IsNotesEmpty => ExistingNotes.Count == 0;

        public ICommand CreateNote { get; private set; }

		public MainViewModel()
		{
			ExistingNotes = new ObservableCollection<Note>();
			_notesRepository = new NoteRepository();
			LoadNotesData();
		}

        public void LoadNotesData()
        {
            //TODO: Add a service layer to perform CRUD on Notes
            ExistingNotes = new ObservableCollection<Note>(_notesRepository.GetAllNotes());
        }
    }
}

