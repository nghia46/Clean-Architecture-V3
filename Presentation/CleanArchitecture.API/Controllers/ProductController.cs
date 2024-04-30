using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Application.Commands;
using CleanArchitecture.Domain.ViewModels;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ISender _sender;
    public ProductController(ISender sender)
    {
        _sender = sender;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _sender.Send(new GetProductsQuery());
        return Ok(products);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var product = await _sender.Send(new GetProductByIdQuery(id));
        return Ok(product);
    }
    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductView product)
    {
        var addedProduct = await _sender.Send(new AddProductCommand(product));
        return Ok(addedProduct);
    }
}