namespace CleanArchitecture.Application.Commons.DTOs;

public class ProductDto
{
    public string Name { get; set; } = null!;
    public Guid CategoryId { get; set; }
    public float Price { get; set; }
}