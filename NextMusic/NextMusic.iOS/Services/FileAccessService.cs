using System;
using Internal;
using NextMusic.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using NextMusic.iOS.Services;
using System.Linq;

[assembly: Dependency(typeof(FileAccessService))]
namespace NextMusic.iOS.Services
{
    public class FileAccessService : IFileAccessService
    {
        public async Task<IEnumerable<string>> GetMusicFilesAsync()
        {
            var musicFiles = new List<string>();

            try
            {
                var folder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                musicFiles.AddRange(Directory.GetFiles(folder, "*.mp3"));

                // Add other audio formats if needed

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

