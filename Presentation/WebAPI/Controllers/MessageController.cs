using Application.Models.common;
using Application.Modules.MessageModule.Command.MessageAddCommand;
using Application.Modules.MessageModule.Command.MessageDeleteCommand;
using Application.Modules.MessageModule.Command.MessageEditCommand;
using Application.Modules.MessageModule.Queries.GetAllQuery;
using Application.Modules.MessageModule.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] MessageGetAllQueryRequest request)
        {
            var data = await mediator.Send(request);
            var response = ApiResponse.Success(data);
            return Ok(response);
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetById([FromQuery] MessageGetByIdRequest request, int id)
        {
            request.Id = id;
            var data = await mediator.Send(request);
            var response = ApiResponse.Success(data);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MessageAddCommandRequest request)
        {
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status201Created);
            return Ok(response);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<IActionResult> Edit([FromBody] MessageEditCommandRequest request, int id)
        {
            request.Id = id;
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status200OK);
            return Ok(response);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> Delete([FromQuery] MessageDeleteCommandRequest request, int id)
        {
            request.Id = id;
            await mediator.Send(request);
            var response = ApiResponse.Success(StatusCodes.Status204NoContent, "Deleted");
            return Ok(response);
        }
    }
}
