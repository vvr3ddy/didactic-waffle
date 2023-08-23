using System;
using PersonalNotes.Models;

namespace PersonalNotes.ViewModels
{
	public class NoteViewModel: BaseViewModel
	{

		private Note _note;
		public Note Note
		{
			get => _note;
			set
			{
				_note = value;
				OnPropertyChanged(nameof(Note));
			}
		}
		public NoteViewModel()
		{
		}
	}
}

