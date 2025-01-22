using Application.Models.common;
using Application.Modules.CategoryModule.Commands.CategoryAddCommand;
using Application.Modules.CategoryModule.Commands.CategoryDeleteCommand;
using Application.Modules.CategoryModule.Commands.CategoryEditCommand;
using Application.Modules.CategoryModule.Queries.CategoryGetAllQuery;
using Application.Modules.CategoryModule.Queries.CategoryGetByIdQuery;
using Application.Modules.CommentModule.Commands;
using Application.Modules.CommentModule.Commands.CommentDeleteCommand;
using Application.Modules.CommentModule.Commands.CommentEditCommand;
using Application.Modules.CommentModule.Queries.CommentGetAllQuery;
using Application.Modules.CommentModule.Queries.CommentGetByCourseId;
using Application.Modules.CommentModule.Queries.CommentGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CommentGetAllQueryRequest request)
        {
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status200OK);
            return Ok(response);
        }

        //[HttpGet("{id:int:min(1)}")]
        //public async Task<IActionResult> GetById([FromQuery] CommentGetByIdQueryRequest request, int id)
        //{
        //    request.Id = id;
        //    var res = await mediator.Send(request);
        //    var response = ApiResponse.Success(res, StatusCodes.Status200OK);
        //    return Ok(response);
        //}
        
        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetAllByCourseId([FromQuery] CommentGetByCourseIdRequest request, int id)
        {
            request.Id = id;
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status200OK);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CommentAddCommandRequest request)
        {
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status201Created);
            return Ok(response);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<IActionResult> Edit([FromBody] CommentEditCommandRequest request, int id)
        {
            request.Id = id;
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status200OK);
            return Ok(response);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> Delete([FromQuery] CommentDeleteCommandRequest request, int id)
        {
            request.Id = id;
            await mediator.Send(request);
            var response = ApiResponse.Success(StatusCodes.Status204NoContent, "Deleted");
            return Ok(response);
        }
    }
}
