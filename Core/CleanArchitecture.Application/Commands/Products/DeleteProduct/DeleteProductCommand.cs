using CleanArchitecture.Application.Commons;
using MediatR;

namespace CleanArchitecture.Application.Commands.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id) : IRequest<BaseResponse<string>>;