using CleanArchitecture.Application.Commons;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces.Repository;
using MediatR;

namespace CleanArchitecture.Application.Commands.Products.UpdateProduct;

public class UpdateProductCommandHandler(IProductRepository repository)
    : IRequestHandler<UpdateProductCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var exitingProduct = await repository.GetByIdAsync(request.Id) ?? throw new InvalidOperationException(nameof(Product));
        var updatedProduct = new Product
        {
            Id = request.Id,
            Name = request.ProductDto.Name,
            Price = request.ProductDto.Price
        };
        await repository.Update(request.Id, updatedProduct);
        return new BaseResponse
        {
            Id = request.Id,
            Message = "Product updated successfully",
            Success = true
        };
    }
}