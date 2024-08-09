using CleanArchitecture.Application.Commons;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Interfaces.Repository;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Commands.Products.AddProduct;

public class CreateProductCommandHandler(IProductRepository productRepository)
    : IRequestHandler<CreateProductCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = NewId.NextSequentialGuid(),
            Name = request.ProductDto.Name,
            Price = request.ProductDto.Price
        };
        await productRepository.Create(product);
        return new BaseResponse
        {
            Id = product.Id,
            Message = "Product created successfully",
            Success = true
        };
    }
}