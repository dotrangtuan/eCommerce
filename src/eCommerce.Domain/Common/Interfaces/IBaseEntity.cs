namespace eCommerce.Domain.Common.Interfaces;

public interface IBaseEntity<TKey>
{
    TKey Id { get; set; }
    bool IsDeleted { get; set; }
}


// public interface IBaseEntity : IBaseEntity<Guid>
// {
// }