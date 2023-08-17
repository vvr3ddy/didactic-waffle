using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NextMusic.Models
{
	public class Song
	{
		public string TrackTitle { get; set; }
		public string AlbumTitle { get; set; }
        public ImageSource AlbumArt { get; set; }
		public List<string> Artists { get; set; }
        public TimeSpan Duration { get; set; }
    }
}

