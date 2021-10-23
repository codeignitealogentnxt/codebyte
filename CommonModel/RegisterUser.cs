﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModel
{
   public class RegisterUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class RegisterUserResponse
    {
        public string UserId { get; set; }
      
    }
}
