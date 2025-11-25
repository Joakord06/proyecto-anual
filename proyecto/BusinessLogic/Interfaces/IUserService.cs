using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace LayeredApp.Business.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
        User GetUserByUsername(string username);
        void CreateUser(User user);
        void UpdateUserPassword(User user);
        IEnumerable<User> GetAllUsers();
    }
}
