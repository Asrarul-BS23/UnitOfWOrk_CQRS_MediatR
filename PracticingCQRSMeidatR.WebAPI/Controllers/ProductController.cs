using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticingCQRSMediatR.Application.UseCases.Products.Commands.CreateProductCommand;
using PracticingCQRSMediatR.Application.UseCases.Products.Queries.GetAllProductQuery;

namespace PracticingCQRSMeidatR.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {  _mediator = mediator; }

    [HttpGet]
    public async Task<ActionResult<List<ProductVM>>> GetAllProducts()
    {
        var products = await _mediator.Send(new GetAllProductQuery());
        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateProduct(CreateProductCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}
