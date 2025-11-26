using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using System.Collections.Generic;

namespace LayeredApp.Business.Interfaces
{
    public interface IUserService
    {
        User? Login(string username, string plainPassword);
        User? GetUserByUsername(string username);
        (string password, bool sent) ResetPasswordBySecurity(string username, IDictionary<int, string> answers);
        bool ChangePasswordFirstTime(int userId, string newPlain, out string reason);
        bool ChangePassword(int userId, string oldPlain, string newPlain, out string reason);
        void CreateUserWithQuestions(User user, IEnumerable<(string Question, string AnswerPlain)> questions);
        SystemConfig GetSystemConfig();
    }
}
