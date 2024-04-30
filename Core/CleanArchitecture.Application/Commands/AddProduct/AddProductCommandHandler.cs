using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Commands;
public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Product>
{
    private readonly IProductRepository _productRepository;
    public AddProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        return _productRepository.AddProductAsync(request.ProductView);
    }
}
