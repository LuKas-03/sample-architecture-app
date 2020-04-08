using Core.Ports;
using System;
using Ninject.Modules;
using Utilities.DI;
using Ninject;
using System.Collections.Generic;
using DemoConsoleApp.Commands;
using System.Linq;
using System.Text;
using DemoConsoleApp.Data;

namespace DemoConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);

            var commands = SetUpCommands(kernel);
            var appContext = new ConsoleAppContext();

            var command = ReadCommand();

            while (command[0] != "exit")
            {
                if (command[0] == "help") PrintHelp(commands);
                else if (commands.ContainsKey(command[0])) 
                {
                    var resultString = commands[command[0]].Execute(command.Skip(1).ToArray(), appContext);
                    Console.WriteLine(resultString);
                }
                else
                {
                    Console.WriteLine("[ERR] Команда не найдена");
                }

                command = ReadCommand();
            }
        }

        static Dictionary<string, IConsoleCommand> SetUpCommands(StandardKernel kernel)
        {
            var userService = kernel.Get<IUserService>();
            var noteService = kernel.Get<INoteService>();

            return new List<IConsoleCommand>
            {
                new LoginUser(userService),
                new CreateNote(noteService),
                new ViewListNotes(noteService)
            }.ToDictionary(e => e.Command);
        }

        static void PrintHelp(Dictionary<string, IConsoleCommand> commands)
        {
            var helpText = new StringBuilder();
            foreach (var command in commands.Values)
            {
                helpText.Append($"{command.Help}\n");
            }
            Console.WriteLine(helpText.ToString());
        } 

        static string[] ReadCommand()
        {
            Console.Write("> ");
            return Console.ReadLine().Split(' ');
        }
    }
}
