using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Commands.Products.AddProduct;

public class CreateProductCommandHandler(IProductRepository productRepository)
    : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = NewId.NextSequentialGuid(),
            Name = request.ProductDto.Name,
            Price = request.ProductDto.Price,
        };
        var createdProduct = await productRepository.AddProductAsync(product);
        return new CreateProductResponse
        {
            Id = createdProduct.Id,
            Message = "Product created successfully",
            Success = true
        };
    }
}