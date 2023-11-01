using Api.Models.Autorizacao;
using Api.Services.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AUTORIZACAO
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly IUserSystemService _userService;
        private readonly TokenService _tokenService;

        public SignInController(IUserSystemService userService, TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public ActionResult SignIn(RequiredCampsForAuthentication User)
        {
            var user = _userService.Authenticate(User.Username, User.Password);

            if (user == null)
                return Unauthorized();

            var token = _tokenService.GenerateToken(user);

            return Ok(new { token });
        }

        [HttpGet("{token}")]
        public ActionResult ValidateToken(string token)
        {
            if(string.IsNullOrEmpty(token)) return Unauthorized();

            var userName = _tokenService.ValidateToken(token);

            if(userName == null) return Unauthorized();

            return Ok(new { userName });
        }
    }
}
