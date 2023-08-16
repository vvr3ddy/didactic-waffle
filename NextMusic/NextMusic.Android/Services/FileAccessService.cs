using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NextMusic.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileAccessService))]
namespace NextMusic.Droid.Services
{
	public class FileAccessService
	{
        public async Task<IEnumerable<string>> GetMusicFilesAsync()
        {
            var musicFiles = new List<string>();

            try
            {
                var folder = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryMusic).AbsolutePath;
                var audioExtensions = new[] { ".mp3" };

                foreach (var extension in audioExtensions)
                {
                    musicFiles.AddRange(Directory.GetFiles(folder, $"*{extension}", SearchOption.AllDirectories));
                }

                return musicFiles;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return Enumerable.Empty<string>();
            }
        }
    }
}

