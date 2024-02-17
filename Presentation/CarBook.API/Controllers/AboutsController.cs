using CarBook.Application.Features.Commands.About.CreateAbout;
using CarBook.Application.Features.Commands.About.RemoveAbout;
using CarBook.Application.Features.Commands.About.UpdateAbout;
using CarBook.Application.Features.Queries.About.GetAllAbout;
using CarBook.Application.Features.Queries.About.GetByIdAbout;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAbout()
        {
            GetAllAboutQueryResponse response = await _mediator.Send(new GetAllAboutQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdAbout([FromRoute] GetByIdAboutQueryRequest request)
        {
            GetByIdAboutQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAbout([FromBody] CreateAboutCommandRequest request)
        {
            CreateAboutCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAbout([FromBody] UpdateAboutCommandRequest request)
        {
            UpdateAboutCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveAbout(string Id)
        {
            RemoveAboutCommandRequest request = new RemoveAboutCommandRequest { Id = Id};
            RemoveAboutCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
