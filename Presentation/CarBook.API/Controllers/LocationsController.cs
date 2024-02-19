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

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdLocation([FromRoute] GetByIdLocationQueryRequest request)
        {
            GetByIdLocationQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationCommandRequest request)
        {
            CreateLocationCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocationCommandRequest request)
        {
            UpdateLocationCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveLocation(string Id)
        {
            RemoveLocationCommandRequest request = new RemoveLocationCommandRequest { Id =Id};
            RemoveLocationCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
