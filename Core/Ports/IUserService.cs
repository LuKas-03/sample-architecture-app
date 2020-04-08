using Domain.Models;

namespace Core.Ports
{
    public interface IUserService
    {
        User GetUserDetails(string userName);
        void AddNewUser(string userName);
    }
}
