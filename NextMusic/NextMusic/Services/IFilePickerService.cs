using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NextMusic.Models;

namespace NextMusic.Services
{
	public interface IFilePickerService
	{
		Task<List<Song>> PickAudioFilesAsync();
	}
}

