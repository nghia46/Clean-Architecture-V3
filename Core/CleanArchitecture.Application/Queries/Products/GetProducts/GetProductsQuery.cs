using CleanArchitecture.Application.Commons;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries.Products.GetProducts;

public record GetProductsQuery : IRequest<BaseResponse<IEnumerable<Product>>>;