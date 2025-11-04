using System.Collections.Generic;
using System.Linq;
using LayeredApp.Data.Entities;

namespace LayeredApp.Data.Repositories
{
    public class UserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>();
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }
    }
}