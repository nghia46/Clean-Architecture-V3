using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Commons.DTOs;

public class CategoryDto
{
    [Required][MaxLength(255)] 
    public string Name { get; set; } = null!;
}