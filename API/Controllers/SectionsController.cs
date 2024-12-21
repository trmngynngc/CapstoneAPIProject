using Application.Core;
using Application.Quizzes;
using Application.Sections;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Details = Application.Sections.Details;
using List = Application.Sections.List;


namespace API.Controllers;

public class SectionsController : ApiController
{
    [HttpGet("list")]
    [SwaggerOperation(Summary = "List Sections")]
    public async Task<ActionResult<ListSectionResponseDTO>> GetSections([FromQuery] PagingParams pagingParams)
    {
        return HandleResult(await Mediator.Send(new List.Query{QueryParams = pagingParams}));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get a Section")]
    public async Task<ActionResult<GetSectionResponseDTO>> GetSection(Guid id)
    {
        return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
    }


}
