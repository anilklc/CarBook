using CarBook.Application.Features.Commands.SocialMedia.CreateSocialMedia;
using CarBook.Application.Features.Commands.SocialMedia.RemoveSocialMedia;
using CarBook.Application.Features.Commands.SocialMedia.UpdateSocialMedia;
using CarBook.Application.Features.Queries.SocialMedia.GetAllSocialMedia;
using CarBook.Application.Features.Queries.SocialMedia.GetByIdSocialMedia;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSocialMedia()
        {
            GetAllSocialMediaQueryResponse response = await _mediator.Send(new GetAllSocialMediaQueryRequest());
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdSocialMedia([FromRoute] GetByIdSocialMediaQueryRequest request)
        {
            GetByIdSocialMediaQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateSocialMedia([FromQuery] CreateSocialMediaCommandRequest request)
        {
            CreateSocialMediaCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateSocialMedia([FromQuery] UpdateSocialMediaCommandRequest request)
        {
            UpdateSocialMediaCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveSocialMedia([FromRoute] RemoveSocialMediaCommandRequest request)
        {
            RemoveSocialMediaCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
