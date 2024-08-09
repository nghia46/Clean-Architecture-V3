using CleanArchitecture.Application.Commons;
using CleanArchitecture.Application.Commons.DTOs;
using MediatR;

namespace CleanArchitecture.Application.Commands.Products.UpdateProduct;

public record UpdateProductCommand(Guid Id, ProductDto ProductDto) : IRequest<BaseResponse>;