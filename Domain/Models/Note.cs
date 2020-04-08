using System;

namespace Domain.Models
{
    public class Note
    {
        public Note(int noteId) : this(noteId, DateTime.Now) { }

        public Note(int noteId, DateTime createDateTime)
        {
            NoteId = noteId;
            CreateDateTime = createDateTime;
        }

        public int NoteId { get; }
        public int AuthorUserId { get; set; }
        public DateTime CreateDateTime { get; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
