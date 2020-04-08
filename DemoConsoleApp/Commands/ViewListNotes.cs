using Core.Ports;
using DemoConsoleApp.Data;
using System;

namespace DemoConsoleApp.Commands
{
    public class ViewListNotes : IConsoleCommand
    {
        private readonly INoteService noteService;

        public ViewListNotes(INoteService noteService)
        {
            this.noteService = noteService;
        }

        public string Command => "note-list";

        public string Help => Command;

        public string Execute(string[] args, ConsoleAppContext appContext)
        {
            if (appContext.CurrentUser == null)
            {
                return "[ERR] Необходимо войти";
            }

            var notes = noteService.GetUserNotes(appContext.CurrentUser.Name);
            if (notes.Length == 0)
            {
                return "[WRN] Заметок нет";
            }

            foreach (var note in notes)
            {
                Console.WriteLine($"[{note.CreateDateTime}] \"{note.Title}\"\n\t{note.Text}");
            }

            return "[OK] -------";
        }
    }
}
