using CarBook.Application.Features.Commands.Comment.CreateComment;
using CarBook.Application.Features.Commands.Comment.RemoveComment;
using CarBook.Application.Features.Commands.Comment.UpdateComment;
using CarBook.Application.Features.Queries.Comment.GetAllComment;
using CarBook.Application.Features.Queries.Comment.GetByIdComment;
using CarBook.Application.Features.Queries.Comment.GetCommentByIdBlog;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllComment()
        {
            GetAllCommentQueryResponse response = await _mediator.Send(new GetAllCommentQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdComment([FromRoute] GetByIdCommentQueryRequest request)
        {
            GetByIdCommentQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentCommandRequest request)
        {
            CreateCommentCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentCommandRequest request)
        {
            UpdateCommentCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveComment(string Id)
        {
            RemoveCommentCommandRequest request = new RemoveCommentCommandRequest { Id = Id };
            RemoveCommentCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{blogId}")]
        public async Task<IActionResult> GetCommentByIdBlog([FromRoute] GetCommentByIdBlogQueryRequest request)
        {
            GetCommentByIdBlogQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
