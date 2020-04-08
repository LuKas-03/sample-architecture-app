using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    internal class NoteEntity
    {
        [Key]
        public int NoteId { get; set; }
        public int AuthorUserId { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
