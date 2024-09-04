using CleanArchitecture.Application.Commons;
using CleanArchitecture.Application.Commons.DTOs;
using MediatR;

namespace CleanArchitecture.Application.Commands.Products.AddProduct;

public record CreateProductCommand(ProductDto ProductDto) : IRequest<BaseResponse<string>>;