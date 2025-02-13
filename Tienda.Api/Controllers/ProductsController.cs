using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tienda.Application.Features.Products.Commands;
using Tienda.Application.Features.Products.Queries;

namespace Tienda.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }
        catch (Exception ex)
        {
            // Log the exception (ex) here if needed
            return StatusCode(500, $"An error occurred while processing your request. {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());
        return Ok(products);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return Ok();
        }
        catch (Exception ex)
        {
            // Log the exception (ex) here if needed
            return StatusCode(500, $"An error occurred while processing your request. {ex.Message}");
        }
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return Ok();
        }
        catch (Exception ex)
        {
            // Log the exception (ex) here if needed
            return StatusCode(500, $"An error occurred while processing your request. {ex.Message}");
        }
    }
}
