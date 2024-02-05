using CarBook.Application.Features.Commands.About.CreateAbout;
using CarBook.Application.Features.Commands.About.RemoveAbout;
using CarBook.Application.Features.Commands.About.UpdateAbout;
using CarBook.Application.Features.Commands.Feature.CreateFeature;
using CarBook.Application.Features.Commands.Feature.RemoveFeature;
using CarBook.Application.Features.Commands.Feature.UpdateFeature;
using CarBook.Application.Features.Queries.About.GetAllAbout;
using CarBook.Application.Features.Queries.About.GetByIdAbout;
using CarBook.Application.Features.Queries.Feature.GetAllFeature;
using CarBook.Application.Features.Queries.Feature.GetByIdFeature;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllFeature()
        {
            GetAllFeatureQueryResponse response = await _mediator.Send(new GetAllFeatureQueryRequest());
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdFeature([FromRoute] GetByIdFeatureQueryRequest request)
        {
            GetByIdFeatureQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateFeature([FromQuery] CreateFeatureCommandRequest request)
        {
            CreateFeatureCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateFeature([FromQuery] UpdateFeatureCommandRequest request)
        {
            UpdateFeatureCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveFeature([FromRoute] RemoveFeatureCommandRequest request)
        {
            RemoveFeatureCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
