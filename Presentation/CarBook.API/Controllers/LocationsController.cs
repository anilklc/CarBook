using CarBook.Application.Features.Commands.Location.CreateLocation;
using CarBook.Application.Features.Commands.Location.RemoveLocation;
using CarBook.Application.Features.Commands.Location.UpdateLocation;
using CarBook.Application.Features.Queries.Location.GetAllLocation;
using CarBook.Application.Features.Queries.Location.GetByIdLocation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllLocation()
        {
            GetAllLocationQueryResponse response = await _mediator.Send(new GetAllLocationQueryRequest());
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdLocation([FromRoute] GetByIdLocationQueryRequest request)
        {
            GetByIdLocationQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateLocation([FromQuery] CreateLocationCommandRequest request)
        {
            CreateLocationCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateLocation([FromQuery] UpdateLocationCommandRequest request)
        {
            UpdateLocationCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveLocation([FromRoute] RemoveLocationCommandRequest request)
        {
            RemoveLocationCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
