using CarBook.Application.Features.Commands.CarFeature.CreateCarFeature;
using CarBook.Application.Features.Commands.CarFeature.UpdateCarFeatureChangeAvailableToFalse;
using CarBook.Application.Features.Commands.CarFeature.UpdateCarFeatureChangeAvailableToTrue;
using CarBook.Application.Features.Queries.CarFeature.GetWithByCarId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetWithByCarId([FromRoute] GetWithByCarIdQueryRequest request)
        {
            GetWithByCarIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCarFeatures([FromBody] CreateCarFeatureCommandRequest  request)
        {
            CreateCarFeatureCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> CarFeatureChangeAvailableToTrue([FromRoute] CarFeatureChangeAvailableToTrueCommandRequest request)
        {
            CarFeatureChangeAvailableToTrueCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> CarFeatureChangeAvailableToFalse([FromRoute] CarFeatureChangeAvailableToFalseCommandRequest request)
        {
            CarFeatureChangeAvailableToFalseCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
