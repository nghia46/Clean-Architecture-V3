using CleanArchitecture.Application.Commons;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) : IRequest<BaseResponse<Product>>;