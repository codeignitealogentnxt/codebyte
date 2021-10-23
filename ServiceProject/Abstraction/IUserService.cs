using CommonModel;
using System.Collections.Generic;

namespace ServiceProject
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);

        IEnumerable<UserModel> GetAll();

        UserModel GetById(int id);

        RegisterUserResponse Register(RegisterUserRequest model);
    }
}