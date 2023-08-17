namespace MobilitywaysCodeTest.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MobilitywaysCodeTest.Context;
    using MobilitywaysCodeTest.Helpers;
    using MobilitywaysCodeTest.Models;
    using MobilitywaysCodeTest.Models.Response;
    using MobilitywaysCodeTest.Services;
    using System.Security.Cryptography;

    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly UserContext _context;
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration, UserContext context)
        {
            _context = context;
            _configuration = configuration;
        }


        [Route("AddUser")]
        [AllowAnonymous]
        [HttpPost]
        public AddUserResponse AddUser(User user)
        {
            var userRepo = new UserRepository(_context);
            return userRepo.AddUser(user);
        }

        [Route("GetToken")]
        [AllowAnonymous]
        [HttpGet]
        public string GetToken(string emailAddress, string password)
        {
            //Check user exists
            var user = _context.Users.FirstOrDefault(u => u.EmailAddress == emailAddress);

            //Check we have a user and the password is correct
            if (user != null && PasswordHasher.Verify(password, user.Password))
            { 
                //Generate token
                TokenRepository tokenRepo = new TokenRepository(_configuration);
                return tokenRepo.GenerateJwtToken(user);
            }

            return string.Empty;
        }

        [Route("GetUsers")]
        [Authorize]
        [HttpGet]
        public List<UserDTO> GetUsers()
        {
            var userRepo = new UserRepository(_context);
            return userRepo.GetUsers();
        }


    }
}
