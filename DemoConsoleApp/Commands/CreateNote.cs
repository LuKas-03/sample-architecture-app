using Core.Ports;
using DemoConsoleApp.Data;
using System;

namespace DemoConsoleApp.Commands
{
    public class CreateNote : IConsoleCommand
    {
        private readonly INoteService noteService;

        public CreateNote(INoteService noteService)
        {
            this.noteService = noteService;
        }

        public string Command => "note-create";
        public string Help => "note-create {title}";
        public string Execute(string[] args, ConsoleAppContext appContext)
        {
            if (appContext.CurrentUser == null)
            {
                return "[ERR] Необходимо войти";
            }

            if (args.Length == 0)
            {
                return "[ERR] Отсуствует параметр title";
            } 

            Console.Write("Ввведине текст записки\n> ");
            var text = Console.ReadLine();

            noteService.AddNewNote(args[0], text, appContext.CurrentUser.Name);
            return "[OK] Заметка создана";
        }
    }
}
