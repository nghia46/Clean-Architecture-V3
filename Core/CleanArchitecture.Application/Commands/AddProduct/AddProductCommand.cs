using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ViewModels;
using MediatR;

namespace CleanArchitecture.Application.Commands.AddProduct;
public record AddProductCommand(ProductView ProductView) : IRequest<Product>;