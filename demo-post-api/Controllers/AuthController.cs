using demo_post_api.Helpers;
using demo_post_api.Models;
using demo_post_api.Repository;
using demo_post_api.Services.Auth;
using demo_post_api.Services.User;
using demo_post_api.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo_post_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtHelper _jwt;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(JwtHelper jwt, IAuthService authService, IUserService userService)
        {
            _jwt = jwt;
            _authService = authService;
            _userService= userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel login)
        {
            string err = "";
            try
            {
                if (login?.Email == null || login?.Password == null)
                {
                    err = "Invalid Email and Password";
                    throw new Exception(err);
                }

                bool isAuthenticated = await _authService.IsAuthenticatedAsync(login?.Email, login?.Password);

                if (!isAuthenticated)
                {
                    err = "Invalid Email and Password";
                    throw new Exception(err);
                }

                var user = await _userService.GetUser(login?.Email);

                var accessToken = _jwt.GenerateToken(user);
                return new JsonResult(new
                {
                    accessToken
                });
            }
            catch(Exception ex)
            {
                return Unauthorized(err);
            }

        }
    }
}
