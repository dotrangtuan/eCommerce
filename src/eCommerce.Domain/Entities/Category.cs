using eCommerce.Domain.Common;

namespace eCommerce.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    
    public string? Description { get; set; }

    #region [REFRENCE PROPERTIES]

    public List<Product> Products { get; set; }

    #endregion
}