using System;
namespace NoteKeeper.Models
{
    public class Note
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string FormattedContent { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public Note()
        {
        }

        public Note(int iD, string title, string formattedContent, DateTime dateCreated, DateTime dateModified)
        {
            ID = iD;
            Title = title;
            FormattedContent = formattedContent;
            DateCreated = dateCreated;
            DateModified = dateModified;
        }
    }

}

