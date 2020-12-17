using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Text.Json;
using UserInfo.Application.Services;
using UserInfo.Infrastructure.Context;

namespace UserInfo.Application.Autofac
{ 
    public static class AutofacConfigurationExtensions
    {
        public static void AddServices(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<UserInfoDbContext>().As<IUserInfoDbContext>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<UsersService>().As<IUsersService>();
            containerBuilder.RegisterType<HttpService>().As<IHttpService>().SingleInstance();
            containerBuilder.Register(ctx => new HttpClient() { BaseAddress = new Uri("https://jsonplaceholder.typicode.com/") })
             .SingleInstance();
        }

        public static IServiceProvider BuildAutofacServiceProvider(this IServiceCollection services)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            containerBuilder.AddServices();

            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }
    }
}
