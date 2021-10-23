using CommonModel;
using ProjectDB.DBModel;
using System.Collections.Generic;

namespace DataRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Authenticate(string username, string password);
        User Register(User user);
    }
}