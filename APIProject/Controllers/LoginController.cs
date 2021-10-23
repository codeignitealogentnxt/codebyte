using APIProject.Helper;
using CommonModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ServiceProject;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserService userService;
        private IJwtService jwtService;

        public LoginController(IUserService userService, IJwtService jwtService)
        {
            this.userService = userService;
            this.jwtService = jwtService;
        }
       

        // POST api/<LoginController>
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest user)
        {
            var response = userService.Authenticate(user);
            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var token = jwtService.GenerateSecurityToken(response);
            return Ok(token);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserRequest model)
        {
            var response = userService.Register(model);
            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(response);
        }
    }
}
