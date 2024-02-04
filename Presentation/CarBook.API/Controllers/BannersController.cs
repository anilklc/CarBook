using CarBook.Application.Features.Commands.Banner.CreateBanner;
using CarBook.Application.Features.Commands.Banner.RemoveBanner;
using CarBook.Application.Features.Commands.Banner.UpdateBanner;
using CarBook.Application.Features.Queries.Banner.GetAllBanner;
using CarBook.Application.Features.Queries.Banner.GetByIdBanner;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BannersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllBanner()
        {
            GetAllBannerQueryResponse response = await _mediator.Send(new GetAllBannerQueryRequest());
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdBanner([FromRoute] GetByIdBannerQueryRequest request)
        {
            GetByIdBannerQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBanner([FromQuery] CreateBannerCommandRequest request)
        {
            CreateBannerCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateBanner([FromQuery] UpdateBannerCommandRequest request)
        {
            UpdateBannerCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveBanner([FromRoute] RemoveBannerCommandRequest request)
        {
            RemoveBannerCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
