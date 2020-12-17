using Microsoft.EntityFrameworkCore;
using UserInfo.Domain.Entities;
using UserInfo.Infrastructure.Configuration;

namespace UserInfo.Infrastructure.Context
{
    public class UserInfoDbContext : DbContext , IUserInfoDbContext
    {
        public UserInfoDbContext(DbContextOptions options) : base(options)
        {
           
        }

        public DbSet<Users> Users { set; get; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsersConfiguration());
            base.OnModelCreating(builder);
        }
    }
}