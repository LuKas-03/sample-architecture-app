using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int userId);
        void AddNewUser(string userName);
        User GetByName(string userName);
    }
}
