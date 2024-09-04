using CleanArchitecture.Application.Commons;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries.Categories.GetCategories;

public record GetCategoriesQuery : IRequest<BaseResponse<IEnumerable<Category>>>;