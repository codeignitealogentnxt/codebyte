using System;

namespace CommonModel
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(UserModel user)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            Username = user.UserName;
            LastName = user.LastName;
            Email = user.Email;
        }
    }

    public class AuthenticateRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
