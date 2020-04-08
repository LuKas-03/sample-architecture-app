using DemoConsoleApp.Data;

namespace DemoConsoleApp
{
    interface IConsoleCommand
    {
        string Command { get; }
        string Help { get; }
        string Execute(string[] args, ConsoleAppContext appContext);
    }
}
