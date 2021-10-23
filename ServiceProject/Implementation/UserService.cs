using CommonModel;
using DataRepository;
using ProjectDB.DBModel;
using System.Collections.Generic;
using System.Linq;

namespace ServiceProject
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userRepository.Authenticate(model.UserName, model.Password);

            // return null if user not found
            if (user == null) return null;

            return new AuthenticateResponse(MapToModel(user));
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _userRepository.GetAll().Select(x => MapToModel(x));
        }

        public UserModel GetById(int id)
        {
            return MapToModel(_userRepository.GetById(id));
        }

        public RegisterUserResponse Register(RegisterUserRequest model)
        {
            User user = new User()
            {
                EmailAddress = model.Email,
                FirstName = model.FirstName,
                IsAccess = true,
                LastName = model.LastName,
                Password = Utils.PasswordHash(model.Password),
                UserName = model.UserName
            };

            UserModel userModel = MapToModel(_userRepository.Register(user));

            return new RegisterUserResponse { UserId = userModel.UserId.ToString() };
        }

        private UserModel MapToModel(User user)
        {
            return new UserModel
            {
                Email = user.EmailAddress,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = "",
                UserId = (int)user.ID,
                UserName = user.UserName,
                IsAdmin = user.IsAdmin
            };
        }
    }
}