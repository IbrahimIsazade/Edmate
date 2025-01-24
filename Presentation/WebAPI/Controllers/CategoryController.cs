using Application.Models.common;
using Application.Modules.CategoryModule.Commands.CategoryAddCommand;
using Application.Modules.CategoryModule.Commands.CategoryDeleteCommand;
using Application.Modules.CategoryModule.Commands.CategoryEditCommand;
using Application.Modules.CategoryModule.Queries.CategoryGetAllPagedQuery;
using Application.Modules.CategoryModule.Queries.CategoryGetAllQuery;
using Application.Modules.CategoryModule.Queries.CategoryGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{page:int:min(1)}/{size:int:min(2)}")]
        public async Task<IActionResult> GetAll([FromBody] CategoryGetAllPagedRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CategoryGetAllQueryRequest request)
        {
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status200OK);
            return Ok(response);
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetById([FromQuery] CategoryGetByIdQueryRequest request, int id)
        {
            request.Id = id;
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status200OK);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryAddCommandRequest request)
        {
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status201Created);
            return Ok(response);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<IActionResult> Edit([FromBody] CategoryEditCommandRequest request, int id)
        {
            request.Id = id;
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status200OK);
            return Ok(response);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> Delete([FromQuery] CategoryDeleteCommandRequest request, int id)
        {
            request.Id = id;
            await mediator.Send(request);
            var response = ApiResponse.Success(StatusCodes.Status204NoContent, "Deleted");
            return Ok(response);
        }
    }
}
