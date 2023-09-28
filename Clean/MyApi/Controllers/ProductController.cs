using Application.Features.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{

    private readonly CreateProductCommand.CreateProductCommandHandler _createProductCommandHandler;
    private readonly GetAllProductsQuery.GetAllProductsQueryHandler _getAllProductsQueryHandler;

    public ProductController(CreateProductCommand.CreateProductCommandHandler createProductCommandHandler,
        GetAllProductsQuery.GetAllProductsQueryHandler getAllProductsQueryHandler)
    {
        _createProductCommandHandler = createProductCommandHandler;
        _getAllProductsQueryHandler = getAllProductsQueryHandler;
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateProductCommand command)
    {
        if (ModelState.IsValid)
        {
            return Ok(await _createProductCommandHandler.Handle(command));
        }

        return BadRequest(ModelState);
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        return Ok(await _getAllProductsQueryHandler.Handle(new GetAllProductsQuery()));
    }
}
