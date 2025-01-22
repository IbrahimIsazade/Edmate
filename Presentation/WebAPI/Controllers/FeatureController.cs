using Application.Models.common;
using Application.Modules.FeatureModule.Commands.AddCommand;
using Application.Modules.FeatureModule.Commands.GetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{id:int:min(1)}/{boolean:bool}")]
        public async Task<IActionResult> GetFeaturesById([FromQuery] FeatureGetAllByIdQueryRequest request, int id, bool boolean)
        {
            request.Id = id;
            request.IsCourse = boolean;

            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status200OK);
            return Ok(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(FeatureAddCommandRequest request)
        {
            var res = await mediator.Send(request);
            var response = ApiResponse.Success(res, StatusCodes.Status201Created);
            return Ok(response);
        }
    }
}
