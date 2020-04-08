using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dataContext;

        public UserRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void AddNewUser(string userName)
        {
            dataContext.Users.Add(new UserEntity
            {
                Name = userName
            });
            dataContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return dataContext.Users
                .Select(e => e.ToUserModel());
        }

        public User GetById(int userId)
        {
            return dataContext.Users
                .FirstOrDefault(e => e.UserId == userId)
                ?.ToUserModel();
        }

        public User GetByName(string userName)
        {
            return dataContext.Users
                .FirstOrDefault(e => e.Name == userName)
                ?.ToUserModel();
        }
    }
}
