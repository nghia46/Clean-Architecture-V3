using CleanArchitecture.Application.Commands.Categories.AddCategory;
using CleanArchitecture.Application.Commons.DTOs;
using CleanArchitecture.Application.Queries.Categories.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ISender sender) : ControllerBase
{
    [HttpGet("Gets")]
    public async Task<IActionResult> Get()
    {
        var categories = await sender.Send(new GetCategoriesQuery());
        return Ok(categories);
    }
    [HttpPost("Add")]
    public async Task<IActionResult> Add(CategoryDto categoryDto)
    {
        var response = await sender.Send(new CreateCategoryCommand(categoryDto));
        return Ok(response);
    }
    [HttpPost("SayHello/{name:string}")]
    public IActionResult SayHello(string name)
    {
        return Ok("Hello " + name);
    }
}