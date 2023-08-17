using MobilitywaysCodeTest.Context;
using MobilitywaysCodeTest.Helpers;
using MobilitywaysCodeTest.Models;
using MobilitywaysCodeTest.Models.Response;
using System.Net.Mail;

namespace MobilitywaysCodeTest.Services
{
    public class UserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public AddUserResponse AddUser(User user)
        {
            var response = new AddUserResponse();

            if (!MailAddress.TryCreate(user.EmailAddress, out var emailAddress))
            {
                response.Success = false;
                response.Message = "Invalid email address";
                return response;
            }

            if (!_context.Users.Any(u => u.EmailAddress == user.EmailAddress))
            {
                var hashedPassword = PasswordHasher.Hash(user.Password);
                user.Password = hashedPassword;

                _context.Users.Add(user);
                _context.SaveChanges();
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "Email address already registred";
            }
            

            return response;
        }

        public List<UserDTO> GetUsers()
        {
            return _context.Users.Select(u => new UserDTO
            {
                Name = u.Name,
                EmailAddress = u.EmailAddress
            }).ToList();
        }
    }
}
