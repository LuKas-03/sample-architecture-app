using Core.Ports;
using Core.Services;
using Domain.Interfaces;
using Ninject.Modules;
using Repository;


namespace Utilities.DI
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<DataContext>().ToSelf().InTransientScope();

            Bind<IUserRepository>().To<UserRepository>().InTransientScope();
            Bind<INoteRepository>().To<NoteRepository>().InTransientScope();

            Bind<IUserService>().To<UserService>().InTransientScope();
            Bind<INoteService>().To<NoteService>().InTransientScope();
        }
    }
}
