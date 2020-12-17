using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserInfo.Domain.Entities;

namespace UserInfo.Infrastructure.Context
{
    public interface IUserInfoDbContext 
    {
         public DbSet<Users> Users { set; get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
