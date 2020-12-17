
namespace UserInfo.Domain.Entities.Shared
{
    public interface IEntityIdentity<T> where T : struct
    {
        T Id { get; set; }
    }
}
