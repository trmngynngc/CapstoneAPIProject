using Application.Quizzes;
using Application.Sections;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Create = Application.Sections.Create;
using Delete = Application.Sections.Delete;
using Edit = Application.Sections.Edit;

namespace API.Controllers.Management;

public class SectionsController : ManagementApiController
{
    [HttpPost]
    [SwaggerOperation(Summary = "Create a Section")]
    public async Task<IActionResult> CreateSection(CreateSectionRequestDTO section)
    {
        return HandleResult(await Mediator.Send(new Create.Command { Section = section}));
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Edit a Section")]
    public async Task<IActionResult> EditSection(Guid id, EditSectionRequestDTO section)
    {
        return HandleResult(await Mediator.Send(new Edit.Command { Id = id, Section = section }));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a Section")]
    public async Task<IActionResult> DeleteSection(Guid id)
    {
        return HandleResult(await Mediator.Send((new Delete.Command { Id = id })));
    }
}
