using Core.Ports;
using Domain.Interfaces;
using Domain.Models;
using Ninject;
using System;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        [Inject]
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void AddNewUser(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            if (userRepository.GetByName(userName) != null)
            {
                throw new ArgumentException("Пользователь с таким именем уже существует");
            }

            userRepository.AddNewUser(userName);
        }

        public User GetUserDetails(string userName)
        {
            return userRepository.GetByName(userName);
        }
    }
}
