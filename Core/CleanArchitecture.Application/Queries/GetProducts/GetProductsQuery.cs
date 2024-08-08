using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries.GetProducts;

public record GetProductsQuery : IRequest<IEnumerable<Product>>;