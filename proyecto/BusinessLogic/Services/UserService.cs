using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repositories;
using LayeredApp.Business.Interfaces;
using System.Security.Cryptography;

namespace LayeredApp.Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

        public void CreateUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public void UpdateUserPassword(User user)
        {
            _userRepository.UpdateUserPassword(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}
