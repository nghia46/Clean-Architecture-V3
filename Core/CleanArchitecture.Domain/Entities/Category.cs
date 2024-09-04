using System.ComponentModel.DataAnnotations;
namespace CleanArchitecture.Domain.Entities;

public class Category
{
    public Guid Id { get; init; }
    [Required][MaxLength(255)] 
    public string Name { get; set; } = null!;
    public ICollection<Product>? Products { get; set; } = new List<Product>();
}