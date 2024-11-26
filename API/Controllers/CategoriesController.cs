using Application.Categories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

public class CategoriesController: ApiController
{
    [HttpGet]
    [SwaggerOperation(Summary = "List Categories")]
    public async Task<ActionResult<ListCategoryResponseDTO>> GetCategories()
    {
        return HandleResult(await Mediator.Send(new List.Query()));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get a Category")]
    public async Task<ActionResult<GetCategoryResponseDTO>> GetCategory(Guid id)
    {
        return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
    }


}
