using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface INoteRepository
    {
        Note GetById(int noteId);
        IEnumerable<Note> GetByUserId(int userId);
        void Add(string title, string text, int authorUserId);
    }
}
