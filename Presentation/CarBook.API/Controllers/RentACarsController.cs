using CarBook.Application.Features.Commands.RentACar.CreateRentACar;
using CarBook.Application.Features.Queries.RentACar.GetRentACarListByLocation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{Id}/{available}")]
        public async Task<IActionResult> GetRentACarListByLocation([FromRoute] GetRentACarListByLocationQueryRequest request)
        {
            GetRentACarListByLocationQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRentACarListByLocation([FromBody] CreateRentACarCommandRequest request)
        {
            CreateRentACarCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
