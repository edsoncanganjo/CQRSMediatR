using CQRSMediatR.Commands;
using CQRSMediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatR.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;

    public ProductsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _sender.Send(new GetProductsQuery());

        return Ok(products);
    }

    [HttpGet("{id:int}", Name = "GetProductById")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _sender.Send(new GetProductByIdQuery(id));

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] Product product)
    {
        var productResult = await _sender.Send(new AddProductCommand(product));

        return CreatedAtRoute("GetProductById", new { id = productResult.Id }, productResult);
    }
}
