using System;

namespace UserInfo.Domain.Entities.Shared
{
    public abstract class EntityIdentity<TKey> : IEntityIdentity<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
