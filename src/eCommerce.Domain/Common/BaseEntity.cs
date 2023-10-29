using System.ComponentModel.DataAnnotations.Schema;
using eCommerce.Domain.Common.Interfaces;
using eCommerce.Shared.Helpers;

namespace eCommerce.Domain.Common;

public abstract class BaseEntity<TKey> :  IBaseEntity<TKey>
{
    [System.ComponentModel.DataAnnotations.Key]
    public TKey Id { get; set; }
    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; } = DateHelper.Now;

    public string CreatedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }
}

public abstract class BaseEntity : BaseEntity<Guid>
{
    
}
