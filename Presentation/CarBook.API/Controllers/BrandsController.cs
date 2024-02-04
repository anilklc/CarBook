using CarBook.Application.Features.Commands.Brand.CreateBrand;
using CarBook.Application.Features.Commands.Brand.RemoveBrand;
using CarBook.Application.Features.Commands.Brand.UpdateBrand;
using CarBook.Application.Features.Queries.Brand.GetAllBrand;
using CarBook.Application.Features.Queries.Brand.GetByIdBrand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAbout()
        {
            GetAllBrandQueryResponse response = await _mediator.Send(new GetAllBrandQueryRequest());
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAbout([FromRoute] GetByIdBrandQueryRequest request)
        {
            GetByIdBrandQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAbout([FromQuery] CreateBrandCommandRequest request)
        {
            CreateBrandCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAbout([FromQuery] UpdateBrandCommandRequest request)
        {
            UpdateBrandCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveAbout([FromRoute] RemoveBrandCommandRequest request)
        {
            RemoveBrandCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
