using Application.Core;
using Application.Products;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

public class ProductsController : ApiController
{
    [HttpGet]
    [SwaggerOperation(Summary = "List Products")]
    public async Task<ActionResult<ListProductResponseDTO>> GetProducts([FromQuery] PagingParams pagingParams)
    {
        return HandleResult(await Mediator.Send(new List.Query{QueryParams = pagingParams}));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get a Product")]
    public async Task<ActionResult<GetProductResponseDTO>> GetProduct(Guid id)
    {
        return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
    }


} 