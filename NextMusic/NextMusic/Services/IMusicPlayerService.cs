using System;
using NextMusic.Models;
using System.Collections.Generic;

namespace NextMusic.Services
{
    public interface IMusicPlayerService
    {
        event Action<Song> OnSongChanged; // Event to notify when the song changes

        bool IsPlaying { get; } // Check if a song is currently playing

        Song CurrentSong { get; } // Get the current playing song

        void Play(Song song); // Play a specific song

        void Pause(); // Pause the current song

        void Resume(); // Resume the paused song

        void Stop(); // Stop the current song

        void Next(); // Move to the next song

        void Previous(); // Move to the previous song

        void SetPlaylist(IEnumerable<Song> songs); // Set a playlist or queue of songs
    }

}

