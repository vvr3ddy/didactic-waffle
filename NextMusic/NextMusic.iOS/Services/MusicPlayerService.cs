using System;
using AVFoundation;
using Foundation;
using NextMusic.Models;
using NextMusic.Services;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using NextMusic.iOS.Services;

[assembly: Dependency(typeof(MusicPlayerService))]
namespace NextMusic.iOS.Services
{
    public class MusicPlayerService : IMusicPlayerService
    {
        // Make it Singleton to ensure the same service persists across the session
        private static readonly Lazy<MusicPlayerService> _instance =
        new Lazy<MusicPlayerService>(() => new MusicPlayerService());

        public static MusicPlayerService Instance => _instance.Value;

        private AVAudioPlayer _player;
        private List<Song> _playlist;
        private int _currentSongIndex = -1;

        public event Action<Song> OnSongChanged;

        public bool IsPlaying => _player?.Playing ?? false;

        public Song CurrentSong => (_currentSongIndex >= 0 && _currentSongIndex < _playlist.Count) ? _playlist[_currentSongIndex] : null;

        public void Play(Song song)
        {
            var audioUrl = NSUrl.FromFilename(song.FilePath);
            _player = AVAudioPlayer.FromUrl(audioUrl);
            _player.Play();

            OnSongChanged?.Invoke(song);
        }

        public void Pause()
        {
            _player?.Pause();
        }

        public void Resume()
        {
            if (_player != null && !_player.Playing)
            {
                _player.Play();
            }
        }

        public void Stop()
        {
            _player?.Stop();
            _player?.Dispose();
            _player = null;
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
    }
}

