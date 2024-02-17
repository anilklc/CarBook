using CarBook.Application.Features.Commands.About.CreateAbout;
using CarBook.Application.Features.Commands.About.RemoveAbout;
using CarBook.Application.Features.Commands.About.UpdateAbout;
using CarBook.Application.Features.Commands.Pricing.CreatePricing;
using CarBook.Application.Features.Commands.Pricing.RemovePricing;
using CarBook.Application.Features.Commands.Pricing.UpdatePricing;
using CarBook.Application.Features.Queries.About.GetAllAbout;
using CarBook.Application.Features.Queries.About.GetByIdAbout;
using CarBook.Application.Features.Queries.Pricing.GetAllPricing;
using CarBook.Application.Features.Queries.Pricing.GetByIdPricing;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPricing()
        {
            GetAllPricingQueryResponse response = await _mediator.Send(new GetAllPricingQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdPricing([FromRoute] GetByIdPricingQueryRequest request)
        {
            GetByIdPricingQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePricing([FromBody] CreatePricingCommandRequest request)
        {
            CreatePricingCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePricing([FromBody] UpdatePricingCommandRequest request)
        {
            UpdatePricingCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemovePricing(string Id)
        {
            RemovePricingCommandRequest request = new RemovePricingCommandRequest { Id = Id };
            RemovePricingCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
