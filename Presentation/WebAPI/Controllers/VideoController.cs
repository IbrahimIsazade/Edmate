using Application.Models.common;
using Application.Modules.VideoModule.Commands.VideoAddCommand;
using Application.Modules.VideoModule.Commands.VideoDeleteCommand;
using Application.Modules.VideoModule.Queries.VideoGetAllQuery;
using Application.Modules.VideoModule.Queries.VideoGetByCourseIdQuery;
using Application.Modules.VideoModule.Queries.VideoGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] VideoGetAllQueryRequest request)
        {
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status200OK);
            return Ok(response);
        }

        //[HttpGet("{id:int:min(1)}")]
        //public async Task<IActionResult> GetById([FromQuery] VideoGetByIdQueryRequest request, int id)
        //{
        //    request.Id = id;
        //    var res = await mediator.Send(request);
        //    var response = ApiResponse.Success(res, StatusCodes.Status200OK);
        //    return Ok(response);
        //}

        [HttpGet("{id:int:min(1)}/{orderNumber:int:min(-1)}")]
        public async Task<IActionResult> GetByCourseId(int id, int orderNumber)
        {
            var request = new VideoGetByCourseIdQueryRequest
            {
                Id = id,
                OrderNumber = orderNumber
            };

            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status200OK);
            return Ok(response);
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Add([FromForm] VideoAddCommandRequest request)
        {
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status201Created);
            return Ok(response);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> Delete([FromQuery] VideoDeleteCommandRequest request, int id)
        {
            request.Id = id;
            await mediator.Send(request);
            var response = ApiResponse.Success(StatusCodes.Status204NoContent, "Deleted");
            return Ok(response);
        }
    }
}
