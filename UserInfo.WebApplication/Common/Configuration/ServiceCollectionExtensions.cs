using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserInfo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace UserInfo.Application.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserInfoDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }               
    }
}
