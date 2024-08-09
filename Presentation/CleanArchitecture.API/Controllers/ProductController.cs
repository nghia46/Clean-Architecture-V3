using CleanArchitecture.Application.Commands.Products.AddProduct;
using CleanArchitecture.Application.Commands.Products.DeleteProduct;
using CleanArchitecture.Application.Commands.Products.UpdateProduct;
using CleanArchitecture.Application.Commons.DTOs;
using CleanArchitecture.Application.Queries.Products.GetProductById;
using CleanArchitecture.Application.Queries.Products.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(ISender sender) : ControllerBase
{
    [HttpGet("Gets")]
    public async Task<IActionResult> Get()
    {
        var products = await sender.Send(new GetProductsQuery());
        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var product = await sender.Send(new GetProductByIdQuery(id));
        return Ok(product);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> AddProduct(ProductDto product)
    {
        var addedProduct = await sender.Send(new CreateProductCommand(product));
        return Ok(addedProduct);
    }
    [HttpPut("Update/{Id:guid}")]
    public async Task<IActionResult> UpdateProduct(Guid Id,ProductDto product)
    {
        var updatedProduct = await sender.Send(new UpdateProductCommand(Id,product));
        return Ok(updatedProduct);
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteProduct(Guid Id)
    {
        await sender.Send(new DeleteProductCommand(Id));
        return Ok();
    }
    
}