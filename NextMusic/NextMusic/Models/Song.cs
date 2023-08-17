using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NextMusic.Models
{
    public class Song
    {
        public string Id { get; set; }          // Unique identifier for the song (can be a file path, database ID, etc.)
        public string Title { get; set; }       // Song title
        public string Artist { get; set; }      // Artist name
        public string Album { get; set; }       // Album name
        public string FilePath { get; set; }    // Path to the music file on the device
        public string AlbumArtPath { get; set; }// Path to the album artwork (if available)
        public TimeSpan Duration { get; set; }  // Duration of the song
    }

}

