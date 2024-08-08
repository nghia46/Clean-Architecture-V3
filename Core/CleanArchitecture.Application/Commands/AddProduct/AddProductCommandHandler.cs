using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Commands.AddProduct;

public class AddProductCommandHandler(IProductRepository productRepository)
    : IRequestHandler<AddProductCommand, Product>
{
    public Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        return productRepository.AddProductAsync(request.ProductView);
    }
}