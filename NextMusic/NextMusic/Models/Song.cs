using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NextMusic.Models
{
	public class Song
	{
		public string Title { get; set; }
		public string AlbumInfo { get; set; }
		public List<string> Artists { get; set; }
		public ImageSource AlbumArt { get; set; }
		public TimeSpan Duration { get; set; }
	}
}

