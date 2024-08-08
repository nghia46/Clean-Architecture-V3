using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities;

public class Product
{
    public Guid Id { get; init; }

    [MaxLength(255)] public string Name { get; init; } = null!;

    public float Price { get; init; }
} 