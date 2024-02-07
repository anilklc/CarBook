using CarBook.Application.Features.Commands.Category.CreateCategory;
using CarBook.Application.Features.Commands.Category.RemoveCategory;
using CarBook.Application.Features.Commands.Category.UpdateCategory;
using CarBook.Application.Features.Queries.Category.GetAllCategory;
using CarBook.Application.Features.Queries.Category.GetByIdCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCategory()
        {
            GetAllCategoryQueryResponse response = await _mediator.Send(new GetAllCategoryQueryRequest());
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdCategory([FromRoute] GetByIdCategoryQueryRequest request)
        {
            GetByIdCategoryQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCategory([FromQuery] CreateCategoryCommandRequest request)
        {
            CreateCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateCategory([FromQuery] UpdateCategoryCommandRequest request)
        {
            UpdateCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveCategory([FromRoute] RemoveCategoryCommandRequest request)
        {
            RemoveCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
