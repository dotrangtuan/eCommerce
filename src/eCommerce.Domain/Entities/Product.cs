using eCommerce.Domain.Common;

namespace eCommerce.Domain.Entities;

public class Product : BaseEntity
{
    public string ProductName { get; set; }
    
    public int UnitPrice { get; set; }
    
    public int UnitsInStock { get; set; }
    
    public Guid CategoryId { get; set; }

    #region [REFRENCE PROPERTIES]
    public virtual Category Category { get; set; }
    
    #endregion
    
}