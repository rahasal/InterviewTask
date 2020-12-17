using AutoMapper;

namespace UserInfo.Application.Common.Mapping
{
    public interface ICustomMap
    {
        void CreateMappings(Profile profile);
    }
}
