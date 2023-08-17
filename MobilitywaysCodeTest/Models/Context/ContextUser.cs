using System.ComponentModel.DataAnnotations;

namespace MobilitywaysCodeTest.Models
{
    public class ContextUser
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }
    }
}
