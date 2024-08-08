using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries.GetProductById;

public record GetProductByIdQuery(Guid Id) : IRequest<Product>;