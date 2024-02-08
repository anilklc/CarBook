using CarBook.Application.Features.Commands.Author.CreateAuthor;
using CarBook.Application.Features.Commands.Author.RemoveAuthor;
using CarBook.Application.Features.Commands.Author.UpdateAuthor;
using CarBook.Application.Features.Queries.Author.GetAllAuthor;
using CarBook.Application.Features.Queries.Author.GetByIdAuthor;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAuthor()
        {
            GetAllAuthorQueryResponse response = await _mediator.Send(new GetAllAuthorQueryRequest());
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAuthor([FromRoute] GetByIdAuthorQueryRequest request)
        {
            GetByIdAuthorQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAuthor([FromQuery] CreateAuthorCommandRequest request)
        {
            CreateAuthorCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAuthor([FromQuery] UpdateAuthorCommandRequest request)
        {
            UpdateAuthorCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveAuthor([FromRoute] RemoveAuthorCommandRequest request)
        {
            RemoveAuthorCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
