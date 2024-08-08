namespace CleanArchitecture.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }
}