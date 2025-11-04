using LayeredApp.Data.Entities;
using LayeredApp.Business.Interfaces;

namespace LayeredApp.Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public void CreateUser(User user)
        {
            _userRepository.AddUser(user);
        }
    }
}