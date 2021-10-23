using CommonModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIProject.Helper
{
    public interface IJwtService
    {
        string GenerateSecurityToken(AuthenticateResponse model);
    }
}
