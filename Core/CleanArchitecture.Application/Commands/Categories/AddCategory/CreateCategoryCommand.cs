using CleanArchitecture.Application.Commons;
using CleanArchitecture.Application.Commons.DTOs;
using MediatR;

namespace CleanArchitecture.Application.Commands.Categories.AddCategory;

public record CreateCategoryCommand(CategoryDto CategoryDto) : IRequest<BaseResponse<string>>;
