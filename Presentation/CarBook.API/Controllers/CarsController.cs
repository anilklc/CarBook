using CarBook.Application.Features.Commands.Banner.CreateBanner;
using CarBook.Application.Features.Commands.Banner.RemoveBanner;
using CarBook.Application.Features.Commands.Banner.UpdateBanner;
using CarBook.Application.Features.Commands.Car.CreateCar;
using CarBook.Application.Features.Commands.Car.RemoveCar;
using CarBook.Application.Features.Commands.Car.UpdateCar;
using CarBook.Application.Features.Queries.Banner.GetAllBanner;
using CarBook.Application.Features.Queries.Banner.GetByIdBanner;
using CarBook.Application.Features.Queries.Car.GetAllCar;
using CarBook.Application.Features.Queries.Car.GetByIdCar;
using CarBook.Application.Features.Queries.Car.GetCarWithBrand;
using CarBook.Application.Features.Queries.Car.GetCarWithBrandWithPricing;
using CarBook.Application.Features.Queries.Car.GetCarWithPricing;
using CarBook.Application.Features.Queries.Car.GetCarWithPricingDay;
using CarBook.Application.Features.Queries.Car.GetLastFiveCar;
using CarBook.Application.Features.Queries.Feature.GetAllFeature;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCar()
        {
            GetAllCarQueryResponse response = await _mediator.Send(new GetAllCarQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdCar([FromRoute] GetByIdCarQueryRequest request)
        {
            GetByIdCarQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCar([FromBody] CreateCarCommandRequest request)
        {
            CreateCarCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCar([FromBody] UpdateCarCommandRequest request)
        {
            UpdateCarCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveCar(string Id)
        {
            RemoveCarCommandRequest request = new RemoveCarCommandRequest { Id = Id };
            RemoveCarCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCarWithBrand()
        {
            GetCarWithBrandQueryResponse response = await _mediator.Send(new GetCarWithBrandQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLastFiveCarWithBrand()
        {
            GetLastFiveCarQueryResponse response = await _mediator.Send(new GetLastFiveCarQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarWithPricing()
        {
            GetCarWithPricingQueryResponse response = await _mediator.Send(new GetCarWithPricingQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarWithPricingDay()
        {
            GetCarWithPricingDayQueryResponse response = await _mediator.Send(new GetCarWithPricingDayQueryRequest());
            return Ok(response);
        }
		[HttpGet("[action]")]
		public async Task<IActionResult> GetCarWithBrandWithPricing()
		{
			GetCarWithBrandWithPricingQueryResponse response = await _mediator.Send(new GetCarWithBrandWithPricingQueryRequest());
			return Ok(response);
		}
	}
}
