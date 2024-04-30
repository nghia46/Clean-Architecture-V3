using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries;

public record GetProductByIdQuery(Guid Id) : IRequest<Product>;
