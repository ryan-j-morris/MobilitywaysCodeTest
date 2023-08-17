using MobilitywaysCodeTest.Context;
using MobilitywaysCodeTest.Helpers;
using MobilitywaysCodeTest.Models;
using MobilitywaysCodeTest.Models.Response;
using System.Net.Mail;

namespace MobilitywaysCodeTest.Repositories
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

            if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.EmailAddress) || string.IsNullOrWhiteSpace(user.Password))
            {
                response.Success = false;
                response.Message = "Please complete all required fields";
            }

            //Is it a vaid email address?
            if (!MailAddress.TryCreate(user.EmailAddress, out var emailAddress))
            {
                response.Success = false;
                response.Message = "Invalid email address";
                return response;
            }

            //Is the email address already registered
            if (_context.Users.Any(u => u.EmailAddress == user.EmailAddress))
            {
                response.Success = false;
                response.Message = "Email address already registred";
                return response;
            }

            //Hash the password so we aren't storing plain text passwords
            var hashedPassword = PasswordHasher.Hash(user.Password);



            var contextUser = new ContextUser
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                EmailAddress = user.EmailAddress,
                Password = hashedPassword
            };
                

            //Add user to the DBContext and save
            _context.Users.Add(contextUser);
            _context.SaveChanges();
            response.Success = true;


            return response;
        }

        public List<UserDTO> GetUsers()
        {
            //Remove the password from the user information before returning
            return _context.Users.Select(u => new UserDTO
            {
                Id = u.Id,
                Name = u.Name,
                EmailAddress = u.EmailAddress
            }).ToList();
        }
    }
}
