using CleanArchitecture.Application.Commons;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Interfaces.Repository;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Commands.Products.AddProduct;

public class CreateProductCommandHandler(IProductRepository productRepository)
    : IRequestHandler<CreateProductCommand, BaseResponse<string>>
{
    public async Task<BaseResponse<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
       
        var productId = NewId.NextSequentialGuid();
        var product = new Product
        {
            Id = productId,
            CategoryId = request.ProductDto.CategoryId,
            Name = request.ProductDto.Name,
            Price = request.ProductDto.Price
        };

        var response = new BaseResponse<string>
        {
            Id = productId,
            Timestamp = DateTime.UtcNow
        };

        try
        {
            // Create product if name does not exist
            await productRepository.Create(product);
            response.Success = true;
            response.Errors = Enumerable.Empty<string>();
            response.Message = "Product created successfully";
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Errors = new[] { ex.Message };
            response.Message = "Failed to create product";
        }

        return response;
    }
}