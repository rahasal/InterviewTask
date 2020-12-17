using AutoMapper;
using System.Collections.Generic;

namespace UserInfo.Application.Common.Mapping
{
    public class CustomMappingProfile : Profile
    {
        public CustomMappingProfile(IEnumerable<ICustomMap> customMappings)
        {
            foreach (var item in customMappings)
                item.CreateMappings(this);
        }
    }
}
