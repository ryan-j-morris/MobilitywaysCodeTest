using Microsoft.EntityFrameworkCore;
using MobilitywaysCodeTest.Models;

namespace MobilitywaysCodeTest.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
    }
}
