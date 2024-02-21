using CarBook.Application.Features.Queries.Statistic.GetAuthorCount;
using CarBook.Application.Features.Queries.Statistic.GetAvgRentPrice;
using CarBook.Application.Features.Queries.Statistic.GetBlogCount;
using CarBook.Application.Features.Queries.Statistic.GetBrandCount;
using CarBook.Application.Features.Queries.Statistic.GetBrandNameByMaxCar;
using CarBook.Application.Features.Queries.Statistic.GetCarCount;
using CarBook.Application.Features.Queries.Statistic.GetCarCountByFuel;
using CarBook.Application.Features.Queries.Statistic.GetCarCountByKm;
using CarBook.Application.Features.Queries.Statistic.GetLocationCount;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLocationCount()
        {
            GetLocationCountQueryResponse response = await _mediator.Send(new GetLocationCountQueryRequest()); 
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarCount()
        {
            GetCarCountQueryResponse response = await _mediator.Send(new GetCarCountQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBrandCount()
        {
            GetBrandCountQueryResponse response = await _mediator.Send(new GetBrandCountQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBlogCount()
        {
            GetBlogCountQueryResponse response = await _mediator.Send(new GetBlogCountQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAuthorCount()
        {
            GetAuthorCountQueryResponse response = await _mediator.Send(new GetAuthorCountQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAvgRentPrice()
        {
            GetAvgRentPriceQueryResponse response = await _mediator.Send(new GetAvgRentPriceQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBrandNameByMaxCar()
        {
            GetBrandNameByMaxCarQueryResponse response = await _mediator.Send(new GetBrandNameByMaxCarQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarCountByFuel()
        {
            GetCarCountByFuelQueryResponse response = await _mediator.Send(new GetCarCountByFuelQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarCountByKm()
        {
            GetCarCountByKmQueryResponse response = await _mediator.Send(new GetCarCountByKmQueryRequest());
            return Ok(response);
        }
    }
}
