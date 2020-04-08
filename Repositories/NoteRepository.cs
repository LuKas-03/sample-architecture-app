using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly DataContext dataContext;

        public NoteRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Add(string title, string text, int authorUserId)
        {
            dataContext.Notes.Add(new NoteEntity
            {
                Title = title,
                Text = text,
                AuthorUserId = authorUserId,
                CreateDateTime = DateTime.Now
            });
            dataContext.SaveChanges();
        }

        public Note GetById(int noteId)
        {
            return dataContext.Notes
                .FirstOrDefault(e => e.NoteId == noteId)
                .ToNoteModel();
        }

        public IEnumerable<Note> GetByUserId(int userId)
        {
            return dataContext.Notes
                .Where(e => e.AuthorUserId == userId)
                .Select(e => e.ToNoteModel());
        }
    }
}
