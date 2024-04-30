using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ViewModels;
using MediatR;

namespace CleanArchitecture.Application.Commands;
public record AddProductCommand(ProductView ProductView) : IRequest<Product>;