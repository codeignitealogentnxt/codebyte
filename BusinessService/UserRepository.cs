using CommonModel;
using ProjectDB;
using ProjectDB.DBModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DataRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ProjectContext projectContext) : base(projectContext)
        {
        }
        public User Authenticate(string username, string password) 
        {
            var user = DbContext.Set<User>().FirstOrDefault(x => x.UserName.ToUpper() == username.ToUpper() && x.IsAccess);
            if(user == null || Utils.PasswordHash(user.Password) == user.Password)
            {
                return null;
            }
            return user;
        }

        public User Register(User user)
        {
            var existingUser = DbContext.Set<User>()
                .FirstOrDefault(x => x.UserName.ToUpper() == user.UserName.ToUpper() ||
                x.EmailAddress.ToUpper() == user.EmailAddress.ToUpper());
            if (existingUser != null) 
            {
                return null;
            }
            
            Add(user);
            return user;
        }
        
    }
}