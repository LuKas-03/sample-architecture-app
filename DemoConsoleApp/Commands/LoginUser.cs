using Core.Ports;
using DemoConsoleApp.Data;

namespace DemoConsoleApp.Commands
{
    public class LoginUser : IConsoleCommand
    {
        private readonly IUserService userService;

        public LoginUser(IUserService userService)
        {
            this.userService = userService;
        }

        public string Command => "login";
        public string Help => Command + " {userName}";

        public string Execute(string[] args, ConsoleAppContext appContext)
        {
            if (args.Length == 0)
            {
                return "[ERR] Отсуствует параметр userName";
            }

            var user = userService.GetUserDetails(args[0]);
            if (user == null)
            {
                return "[ERR] ПОльзователь с таким userName не найден";
            }

            appContext.CurrentUser = user;
            return "[OK] Вход выполнен";
        }
    }
}
