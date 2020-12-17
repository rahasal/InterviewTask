using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using UserInfo.Domain.Entities;

namespace UserInfo.Infrastructure.Configuration
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.Property(x => x.InsertDate).HasDefaultValueSql("getdate()").ValueGeneratedOnAddOrUpdate();
            builder.Property(x => x.ModifyDate).HasDefaultValueSql("getdate()").ValueGeneratedOnAddOrUpdate();

            builder.HasData(new Users()
            {
                Id = 1,
                FirstName = "raha",
                LastName = "salehour",
                EmailAddress = "raha.salehpour@gmail.com",
                Password = "123456",
                BirthDate = DateTime.Now.Date,
                UserType = Domain.Enum.UserType.GuestUser,
                Active = true
            });
            builder.HasData(new Users()
            {
                Id = 2,
                FirstName = "azade",
                LastName = "salehour",
                EmailAddress = "azade.salehpour@gmail.com",
                Password = "1234",
                BirthDate = DateTime.Now.Date,
                UserType = Domain.Enum.UserType.PowerUser,
                Active = true
            });
         
        }
    }
}
