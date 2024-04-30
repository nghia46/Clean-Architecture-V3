using MediatR;
using CleanArchitecture.Domain.Entities;
namespace CleanArchitecture.Application.Queries;
public record GetProductsQuery() : IRequest<IEnumerable<Product>>;

