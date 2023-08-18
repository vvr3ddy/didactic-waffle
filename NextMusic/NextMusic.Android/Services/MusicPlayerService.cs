using System;
using System.Collections.Generic;
using NextMusic.Droid.Services;
using NextMusic.Models;
using NextMusic.Services;
using Xamarin.Forms;
using Android.Media;
using System.Linq;

[assembly: Dependency(typeof(MusicPlayerService))]
namespace NextMusic.Droid.Services
{
	public class MusicPlayerService : IMusicPlayerService
	{
        // Make it Singleton to ensure the same service persists across the session
        private static readonly Lazy<MusicPlayerService> _instance =
        new Lazy<MusicPlayerService>(() => new MusicPlayerService());

        public static MusicPlayerService Instance => _instance.Value;
        private MediaPlayer _mediaPlayer;
        private List<Song> _playlist;
        private int _currentSongIndex = -1;

        public event Action<Song> OnSongChanged;

        public bool IsPlaying => _mediaPlayer?.IsPlaying ?? false;

        public Song CurrentSong => (_currentSongIndex >= 0 && _currentSongIndex < _playlist.Count) ? _playlist[_currentSongIndex] : null;

        public void Play(Song song)
        {
            if (_mediaPlayer == null)
            {
                _mediaPlayer = new MediaPlayer();
            }
            else
            {
                _mediaPlayer.Reset();
            }

            _mediaPlayer.SetDataSource(song.FilePath);
            _mediaPlayer.Prepare();
            _mediaPlayer.Start();

            OnSongChanged?.Invoke(song);
        }

        public void Pause()
        {
            _mediaPlayer?.Pause();
        }

        public void Resume()
        {
            if (_mediaPlayer != null && !_mediaPlayer.IsPlaying)
            {
                _mediaPlayer.Start();
            }
        }

        public void Stop()
        {
            _mediaPlayer?.Stop();
            _mediaPlayer?.Reset();
        }

        public void Next()
        {
            if (_playlist != null && _currentSongIndex < _playlist.Count - 1)
            {
                _currentSongIndex++;
                Play(_playlist[_currentSongIndex]);
            }
        }

        public void Previous()
        {
            if (_playlist != null && _currentSongIndex > 0)
            {
                _currentSongIndex--;
                Play(_playlist[_currentSongIndex]);
            }
        }

        public void SetPlaylist(IEnumerable<Song> songs)
        {
            _playlist = songs.ToList();
        }

        // Dispose mediaPlayer properly
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _mediaPlayer?.Release();
                _mediaPlayer = null;
            }
        }
    }
}

