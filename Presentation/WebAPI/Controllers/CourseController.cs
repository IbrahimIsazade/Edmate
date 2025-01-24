using Application.Models.common;
using Application.Modules.CourseModule.Commands.CourseAddCommand;
using Application.Modules.CourseModule.Commands.CourseDeleteCommand;
using Application.Modules.CourseModule.Commands.CourseEditCommand;
using Application.Modules.CourseModule.Queries.CourseGetAllQuery;
using Application.Modules.CourseModule.Queries.CourseGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(IMediator mediator, ICourseRepository courseRepository) : ControllerBase
    {
        [HttpGet("{page:int:min(1)}/{size:int:min(2)}")]
        public async Task<IActionResult> GetAll(int page, int size)
        {
            var query = courseRepository.GetAll();

            var recordCount = query.Count();

            var pages = (int)Math.Ceiling((page * 1D) / size);

            var data = query
                .Skip( (page - 1) * size)
                .Take(size)
                .ToList();

            return Ok(new
            {
                page,
                pages,
                size,
                count = recordCount,
                data = data
            });
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CourseGetAllQueryRequest request)
        {
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status200OK);
            return Ok(response);
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetById([FromQuery] CourseGetByIdQueryRequest request, int id)
        {
            request.Id = id;
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status200OK);
            return Ok(response);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Add([FromForm] CourseAddCommandRequest request)
        {
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status201Created);
            return Ok(response);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<IActionResult> Edit([FromForm] CourseEditCommandRequest request, int id)
        {
            request.Id = id;
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status200OK);
            return Ok(response);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> Delete([FromQuery] CourseDeleteCommandRequest request, int id)
        {
            request.Id = id;
            await mediator.Send(request);
            var response = ApiResponse.Success(StatusCodes.Status204NoContent, "Deleted");
            return Ok(response);
        }
    }
}
