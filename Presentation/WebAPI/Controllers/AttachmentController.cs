using Application.Models.common;
using Application.Modules.AttachmentModule.Commands.AttachmentAddCommnad;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AttachmentAddCommandRequest request)
        {
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status201Created);
            return Ok(response);
        }
    }
}
