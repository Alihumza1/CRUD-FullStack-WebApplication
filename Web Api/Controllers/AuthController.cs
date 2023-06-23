using ClassLibrary2.Entity;
using ClassLibrary2.Reposiotory;
using ClassLibrary2.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Web_Api.Models;
namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmployeeController> _logger;
        public AuthController(ILogger<EmployeeController> logger, IUserRepository _user, IConfiguration configuration)
        {
            _userRepository = _user;
            _configuration = configuration;
            _logger = logger;
        }
        [HttpPost("Register")]
        public IActionResult Register(UserModel userModel)
        {

            User users = new User();
            users.UserName = userModel.UserName;
            users.PassWord = userModel.PassWord;
            _userRepository.AddUser(users);
            return Created("Created Successfully", users);

        }
        [HttpPost("Login")]
        public IActionResult GetUser(UserModel userModel)
        {

            User users = new User();
            users.UserName = userModel.UserName;
            users.PassWord = userModel.PassWord;
            var user = _userRepository.GetUser(users);
            if (user == null)
            {
                return BadRequest("Record not Matched");
            }
            string token = CreateToken(user);
            return Ok(new { token = token });

        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
              new Claim(ClaimTypes.Name,user.UserName),
            };
            var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Key").Value));
            var cred = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
