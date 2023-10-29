using eCommerce.Application.Infrastructure;

namespace eCommerce.Application.Features.Product.Command.Create;

public class CreateProductCommandHandler
{
    private readonly IProductWriteOnlyRepository _productWriteOnlyRepository;
    
    public CreateProductCommandHandler(IProductWriteOnlyRepository productWriteOnlyRepository)
    {
        _productWriteOnlyRepository = productWriteOnlyRepository;
    }
}