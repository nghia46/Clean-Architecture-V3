using CleanArchitecture.Application.Commons;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces.Repository;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Queries.Products.GetProducts;

public class GetProductsQueryHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductsQuery, BaseResponse<IEnumerable<Product>>>
{
    public async Task<BaseResponse<IEnumerable<Product>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<Product>>()
        {
            Id = NewId.NextSequentialGuid(),
            Timestamp = DateTime.UtcNow,
        };
        try
        {
            var products = await productRepository.GetsAsync();
            response.Message = "Products retrieved successfully";
            response.Success = true;
            response.Data = products;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Success = false;
        }
        return response;
    }
}