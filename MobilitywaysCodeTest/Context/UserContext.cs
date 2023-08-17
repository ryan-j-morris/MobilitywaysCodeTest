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

        public DbSet<ContextUser> Users { get; set; } = null!;
    }
}
