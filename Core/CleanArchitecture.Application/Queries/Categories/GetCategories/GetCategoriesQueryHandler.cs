using CleanArchitecture.Application.Commons;
using CleanArchitecture.Application.Interfaces.Repository;
using CleanArchitecture.Domain.Entities;
using MassTransit;
using MediatR;

namespace CleanArchitecture.Application.Queries.Categories.GetCategories;

public class GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
    : IRequestHandler<GetCategoriesQuery, BaseResponse<IEnumerable<Category>>>
{
    public async Task<BaseResponse<IEnumerable<Category>>> Handle(GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<Category>>
        {
            Id = NewId.NextSequentialGuid(),
            Timestamp = DateTime.UtcNow,
        };
        try
        {
            var categories = await categoryRepository.GetsAsync();
            response.Data = categories;
            response.Success = true;
            response.Message = "Categories retrieved successfully";
            response.Errors = Enumerable.Empty<string>();
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = "An error occurred.";
            response.Errors = new[] { ex.Message };
        }

        return response;
    }
}