using CleanArchitecture.Application.Commons;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces.Repository;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Commands.Categories.AddCategory;

public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<CreateCategoryCommand, BaseResponse<string>>
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

        return response;
    }
}