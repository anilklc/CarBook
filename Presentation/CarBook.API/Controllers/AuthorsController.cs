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

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdAuthor([FromRoute] GetByIdAuthorQueryRequest request)
        {
            GetByIdAuthorQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorCommandRequest request)
        {
            CreateAuthorCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorCommandRequest request)
        {
            UpdateAuthorCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveAuthor(string Id)
        {
            RemoveAuthorCommandRequest request = new RemoveAuthorCommandRequest { Id = Id };
            RemoveAuthorCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
