using CleanArchitecture.Application.Commons;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces.Repository;
using MediatR;

namespace CleanArchitecture.Application.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandHandler(IProductRepository repository)
        : IRequestHandler<UpdateProductCommand, BaseResponse<string>>
    {
        public async Task<BaseResponse<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<string>
            {
                Id = request.Id,
                Timestamp = DateTime.UtcNow
            };

            try
            {
                var existingProduct = await repository.GetByIdAsync(request.Id);
                var updatedProduct = new Product
                {
                    Id = request.Id,
                    Name = request.ProductDto.Name,
                    Price = request.ProductDto.Price
                };

                await repository.Update(request.Id, updatedProduct);

                response.Success = true;
                response.Message = "Product updated successfully";
                response.Errors = Enumerable.Empty<string>();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Failed to update product";
                response.Errors = new[] { ex.Message };
            }

            return response;
        }
    }
}
