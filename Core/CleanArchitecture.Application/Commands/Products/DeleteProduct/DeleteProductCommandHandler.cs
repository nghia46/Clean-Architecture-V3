using CleanArchitecture.Application.Commons;
using CleanArchitecture.Domain.Constants;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Interfaces.AMQP;
using CleanArchitecture.Domain.Interfaces.Repository;
using MediatR;

namespace CleanArchitecture.Application.Commands.Products.DeleteProduct;

public class DeleteProductCommandHandler(IMessagePublisher messagePublisher, IProductRepository repository)
    : IRequestHandler<DeleteProductCommand, BaseResponse<string>>
{
    public async Task<BaseResponse<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<string>
        {
            Id = request.Id,
            Timestamp = DateTime.UtcNow
        };
        try
        {
            await repository.DeleteAsync(request.Id);
            response.Success = true;
            response.Message = "Product deleted successfully";
            response.Errors = Enumerable.Empty<string>();
            // Send the BorrowingRequest to the BorrowingQueue for processing
            await messagePublisher.PublishAsync(response, QueueName.ProductQueue, cancellationToken);
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = "Failed to delete product";
            response.Errors = new[] { e.Message };
        }
        
        return response;
    }
}