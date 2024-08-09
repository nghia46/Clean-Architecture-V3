using CleanArchitecture.Application.Commons;
using CleanArchitecture.Domain.Constants;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Application.Commands.Products.DeleteProduct;

public class DeleteProductCommandHandler(IMessagePublisher messagePublisher,IProductRepository repository)
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
        var response = new BaseResponse()
        {
            Id = product.Id,
            Message = "Product deleted successfully",
            Success = true
        };

        // Send the BorrowingRequest to the BorrowingQueue for processing
        await messagePublisher.PublishAsync(response, QueueName.ProductQueue, cancellationToken);
        
        return response;
    }
}