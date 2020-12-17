using AutoMapper;
using UserInfo.Application.Common.Mapping;

namespace UserInfo.Application
{
    public abstract class BaseDto<TEntity> : ICustomMap
    {

        public void CreateMappings(Profile profile)
        {
            var mappingExpression = profile.CreateMap(GetType(),typeof(TEntity)).ReverseMap();
        }
    }
}

