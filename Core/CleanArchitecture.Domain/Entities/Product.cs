﻿using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities;

public class Product
{
    public Guid Id { get; init; }
    public Guid CategoryId { get; set; }
    [MaxLength(255)] public string Name { get; set; } = null!;
    public float Price { get; set; }
}