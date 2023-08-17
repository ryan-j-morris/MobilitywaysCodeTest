using System.ComponentModel.DataAnnotations;

namespace MobilitywaysCodeTest.Models
{
    public class User
    {
        public string Name { get; set; }

        [Key]
        public string EmailAddress { get; set; }

        public string Password { get; set; }

    }
}
