using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NoteKeeper.Models;

namespace NoteKeeper.Repositories
{
    public class NoteRepository
    {
        public List<Note> Notes { get; set; }

        public NoteRepository()
        {
            Notes = new List<Note>
            {
                new Note(1, "Grocery List", "<strong>Apples</strong>, <em>Oranges</em>, Bananas", DateTime.Now.AddDays(-3), DateTime.Now),
                new Note(2, "Meeting Notes", "Discuss <strong>project timeline</strong> and <em>milestones</em>", DateTime.Now.AddDays(-2), DateTime.Now),
                new Note(3, "Workout Plan", "<strong>Monday:</strong> Cardio, <em>Tuesday:</em> Strength", DateTime.Now.AddDays(-1), DateTime.Now),
                new Note(4, "Reading List", "<strong>Books:</strong> <em>To Kill a Mockingbird</em>, 1984", DateTime.Now, DateTime.Now)
            };
        }

        public List<Note> GetAllNotes()
        {
            return Notes;
        }

        public Note GetNoteById(int id)
        {
            return Notes.Find(note => note.ID == id);
        }

        public void AddNote(Note newNote)
        {
            NoteRepository.RemoveFormattingAndSetContent(newNote);
            Notes.Add(newNote);
        }

        public void UpdateNote(Note updatedNote)
        {
            NoteRepository.RemoveFormattingAndSetContent(updatedNote);
            var existingNote = GetNoteById(updatedNote.ID);
            if (existingNote != null)
            {
                existingNote.Title = updatedNote.Title;
                existingNote.Content = updatedNote.Content;
                existingNote.FormattedContent = updatedNote.FormattedContent;
                existingNote.DateModified = DateTime.Now;
            }
        }

        public void DeleteNote(int id)
        {
            var noteToDelete = GetNoteById(id);
            if (noteToDelete != null)
            {
                Notes.Remove(noteToDelete);
            }
        }

        private static void RemoveFormattingAndSetContent(Note note)
        {
            var plainText = Regex.Replace(note.FormattedContent, "<.*?>", string.Empty);
            note.Content = plainText;
        }
    }
}
