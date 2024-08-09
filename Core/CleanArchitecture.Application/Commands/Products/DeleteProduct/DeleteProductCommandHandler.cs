using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Commands.Products.DeleteProduct;

public class DeleteProductCommandHandler(IProductRepository repository)
    : IRequestHandler<DeleteProductCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await repository.GetByIdAsync(request.Id);
        if (product == null)
        {
            throw new InvalidOperationException(nameof(Product));
        }

        await repository.DeleteAsync(product.Id);

        return new BaseResponse()
        {
            Id = product.Id,
            Message = "Success",
            Success = true
        };
    }
}