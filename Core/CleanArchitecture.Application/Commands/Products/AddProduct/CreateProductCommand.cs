using CleanArchitecture.Application.Commons.DTOs;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Commands.Products.AddProduct;

public record CreateProductCommand(ProductDto ProductDto) : IRequest<CreateProductResponse>;