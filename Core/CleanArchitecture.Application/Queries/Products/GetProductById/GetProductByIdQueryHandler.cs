using CleanArchitecture.Application.Commons;
using CleanArchitecture.Application.Interfaces.Repository;
using CleanArchitecture.Domain.Entities;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Queries.Products.GetProductById;

public class GetProductByIdQueryHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductByIdQuery, BaseResponse<Product>>
{
    public async Task<BaseResponse<Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<Product>()
        {
            Id = NewId.NextSequentialGuid(),
            Timestamp = DateTime.UtcNow,
        };
        try
        {
            var product = await productRepository.GetByIdAsync(request.Id);
            response.Data = product;
            response.Success = true;
            response.Message = "Product retrieved successfully";
            response.Errors = Enumerable.Empty<string>();
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = "An error occurred.";
            response.Errors = new[] { e.Message };
            
        }
        return response;
    }
}