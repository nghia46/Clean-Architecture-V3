namespace CleanArchitecture.Application.Commands.Products.AddProduct;

public class CreateProductResponse
{
    public Guid Id { get; set; }
    public bool Success { get; set; }
    public string? Message { get; set; }
}