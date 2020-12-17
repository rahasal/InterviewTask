using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace UserInfo.Application.Common.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeAutoMapper(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddAutoMapper(config =>
            {
                config.AddCustomMappingProfile();
                config.Advanced.BeforeSeal(configProvicer =>
                {
                    configProvicer.CompileMappings();
                });
            }, assemblies);

        }

        public static void AddCustomMappingProfile(this IMapperConfigurationExpression config)
        {
            config.AddCustomMappingProfile(Assembly.GetExecutingAssembly());
        }

        public static void AddCustomMappingProfile(this IMapperConfigurationExpression config, Assembly assembly)
        {
            var allTypes = assembly.ExportedTypes;

            var list = allTypes.Where(type => type.IsClass && !type.IsAbstract &&
                type.GetInterfaces().Contains(typeof(ICustomMap)))
                .Select(type => (ICustomMap)Activator.CreateInstance(type));

            var profile = new CustomMappingProfile(list);

            config.AddProfile(profile);
        }
    }
}
