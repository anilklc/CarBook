using CarBook.Application.Features.Commands.CarDescription.CreateCarDescription;
using CarBook.Application.Features.Queries.CarDescription;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarDescriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetCarDescriptionWithByCarId([FromRoute] GetCarDescriptionWithByCarIdRequest request)
        {
            GetCarDescriptionWithByCarIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCarDescription([FromBody] CreateCarDescriptionRequest request)
        {
            CreateCarDescriptionResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
