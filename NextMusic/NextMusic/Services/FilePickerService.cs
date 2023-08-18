using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NextMusic.Models;
using Xamarin.Essentials;

namespace NextMusic.Services
{
	public class FilePickerService: IFilePickerService
	{
        public async Task<List<Song>> PickAudioFilesAsync()
        {
            try
            {
                var audioFileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    {DevicePlatform.iOS, new[] {"public.audio"} },
                    {DevicePlatform.Android, new[] {"audio/*"} },
                });
                var pickedFiles = await FilePicker.PickMultipleAsync(new PickOptions
                {
                    FileTypes = audioFileTypes,
                    PickerTitle = "Pick Audio Files"
                });

                if (pickedFiles == null) return new List<Song>(); //TODO: Probably add a custom exception if nothing was picked
                var songs = pickedFiles.Select(file => new Song
                {
                    Id = file.FileName,
                    FilePath = file.FullPath,
                    Title = Path.GetFileNameWithoutExtension(file.FileName)
                }).ToList();
                return songs;

            }catch(Exception ex)
            {
                //TODO: Probably handle the exception with a custom exception header
                return new List<Song>();
            }
        }
    }
}

