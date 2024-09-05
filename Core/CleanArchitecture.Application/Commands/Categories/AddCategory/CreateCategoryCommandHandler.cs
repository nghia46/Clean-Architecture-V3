using CleanArchitecture.Application.Commons;
using CleanArchitecture.Application.Interfaces.Repository;
using CleanArchitecture.Domain.Entities;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Commands.Categories.AddCategory;

public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMongoRepository<PushLogger> loggerRepository) : IRequestHandler<CreateCategoryCommand, BaseResponse<string>>
{
    public async Task<BaseResponse<string>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Id = NewId.NextSequentialGuid(),
            Name = request.CategoryDto.Name
        };
        
        var response = new BaseResponse<string>
        {
            Id = category.Id,
            Timestamp = DateTime.UtcNow
        };
        
        try
        {
            await categoryRepository.Create(category);
            response.Success = true;
            response.Message = "Category created successfully";
            response.Errors = Enumerable.Empty<string>();
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = "Failed to create category";
            response.Errors = new[] { e.Message };
        }
        // Log the response message
        await loggerRepository.Create(new PushLogger() { Id = NewId.NextSequentialGuid(), Info = response.Message });
        
        return response;
    }
}