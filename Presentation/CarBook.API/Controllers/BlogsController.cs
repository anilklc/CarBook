using CarBook.Application.Features.Commands.Blog.CreateBlog;
using CarBook.Application.Features.Commands.Blog.RemoveBlog;
using CarBook.Application.Features.Commands.Blog.UpdateBlog;
using CarBook.Application.Features.Queries.Blog.GetAllBlog;
using CarBook.Application.Features.Queries.Blog.GetBlogWithAuthor;
using CarBook.Application.Features.Queries.Blog.GetByIdBlog;
using CarBook.Application.Features.Queries.Blog.GetLastThreeBlog;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllBlog()
        {
            GetAllBlogQueryResponse response = await _mediator.Send(new GetAllBlogQueryRequest());
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdBlog([FromRoute] GetByIdBlogQueryRequest request)
        {
            GetByIdBlogQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBlog([FromQuery] CreateBlogCommandRequest request)
        {
            CreateBlogCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateBlog([FromQuery] UpdateBlogCommandRequest request)
        {
            UpdateBlogCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveBlog([FromRoute] RemoveBlogCommandRequest request)
        {
            RemoveBlogCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLastThreeBlog()
        {
            GetLastThreeBlogQueryResponse response = await _mediator.Send(new GetLastThreeBlogQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBlogWithAuthor()
        {
            GetBlogWithAuthorQueryResponse response = await _mediator.Send(new GetBlogWithAuthorQueryRequest());
            return Ok(response);
        }
    }
}
