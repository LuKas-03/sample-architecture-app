using Domain.Models;

namespace Core.Ports
{
    public interface INoteService
    {
        Note[] GetUserNotes(string userName);
        Note GetNoteById(int noteId);

        void AddNewNote(string title, string text, string userName);
    }
}
