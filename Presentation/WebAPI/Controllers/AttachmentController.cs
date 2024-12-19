using Application.Models.common;
using Application.Modules.AttachmentModule.Commands.AttachmentAddCommnad;
using Application.Modules.AttachmentModule.Commands.AttachmentDeleteCommand;
using Application.Modules.AttachmentModule.Commands.AttachmentEditCommand;
using Application.Modules.AttachmentModule.Queries.AttachmentGetAllQuery;
using Application.Modules.AttachmentModule.Queries.AttachmentGetByIdQuery;
using Application.Modules.CourseModule.Commands.CourseDeleteCommand;
using Application.Modules.CourseModule.Commands.CourseEditCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] AttachmentGetAllQueryRequest request)
        {
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status200OK);
            return Ok(response);
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetById([FromQuery] AttachmentGetByIdQueryRequest request, int id)
        {
            request.Id = id;
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status200OK);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AttachmentAddCommandRequest request)
        {
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status201Created);
            return Ok(response);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<IActionResult> Edit([FromQuery] AttachmentEditCommandRequest request, int id)
        {
            request.Id = id;
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status200OK);
            return Ok(response);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> Delete([FromQuery] AttachmentDeleteCommandRequest request, int id)
        {
            request.Id = id;
            await mediator.Send(request);
            var response = ApiResponse.Success(StatusCodes.Status204NoContent, "Deleted");
            return Ok(response);
        }
    }
}
