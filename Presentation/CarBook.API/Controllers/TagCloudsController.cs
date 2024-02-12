using CarBook.Application.Features.Commands.About.CreateAbout;
using CarBook.Application.Features.Commands.About.RemoveAbout;
using CarBook.Application.Features.Commands.About.UpdateAbout;
using CarBook.Application.Features.Commands.TagCloud.CreateTagCloud;
using CarBook.Application.Features.Commands.TagCloud.RemoveTagCloud;
using CarBook.Application.Features.Commands.TagCloud.UpdateTagCloud;
using CarBook.Application.Features.Queries.About.GetAllAbout;
using CarBook.Application.Features.Queries.About.GetByIdAbout;
using CarBook.Application.Features.Queries.TagCloud.GetAllTagCloud;
using CarBook.Application.Features.Queries.TagCloud.GetAllTagCloudBlogById;
using CarBook.Application.Features.Queries.TagCloud.GetByIdTagCloud;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllTagCloud()
        {
            GetAllTagCloudQueryResponse response = await _mediator.Send(new GetAllTagCloudQueryRequest());
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdTagCloud([FromRoute] GetByIdTagCloudQueryRequest request)
        {
            GetByIdTagCloudQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTagCloud([FromQuery] CreateTagCloudCommandRequest request)
        {
            CreateTagCloudCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateTagCloud([FromQuery] UpdateTagCloudCommandRequest request)
        {
            UpdateTagCloudCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveTagCloud([FromRoute] RemoveTagCloudCommandRequest request)
        {
            RemoveTagCloudCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]{Id}")]
        public async Task<IActionResult> GetAllTagCloudById([FromRoute] GetAllTagCloudBlogByIdQueryRequest request)
        {
            GetAllTagCloudBlogByIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
