namespace LayeredApp.Business.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
        void CreateUser(User user);
    }
}