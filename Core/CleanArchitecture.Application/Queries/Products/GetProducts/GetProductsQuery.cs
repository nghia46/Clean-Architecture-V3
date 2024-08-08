using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries.Products.GetProducts;

public record GetProductsQuery : IRequest<IEnumerable<Product>>;