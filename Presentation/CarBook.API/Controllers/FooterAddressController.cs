using CarBook.Application.Features.Commands.About.CreateAbout;
using CarBook.Application.Features.Commands.About.RemoveAbout;
using CarBook.Application.Features.Commands.About.UpdateAbout;
using CarBook.Application.Features.Commands.FooterAddress.CreateFooterAddress;
using CarBook.Application.Features.Commands.FooterAddress.RemoveFooterAddress;
using CarBook.Application.Features.Commands.FooterAddress.UpdateFooterAddress;
using CarBook.Application.Features.Queries.About.GetAllAbout;
using CarBook.Application.Features.Queries.About.GetByIdAbout;
using CarBook.Application.Features.Queries.FooterAddress.GetAllFooterAddress;
using CarBook.Application.Features.Queries.FooterAddress.GetByIdFooterAddress;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllFooterAdress()
        {
            GetAllFooterAddressQueryResponse response = await _mediator.Send(new GetAllFooterAddressQueryRequest());
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdFooterAddress([FromRoute] GetByIdFooterAddressQueryRequest request)
        {
            GetByIdFooterAddressQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateFooterAddress([FromQuery] CreateFooterAddressCommandRequest request)
        {
            CreateFooterAddressCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateFooterAddress([FromQuery] UpdateFooterAddressCommandRequest request)
        {
            UpdateFooterAddressCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveFooterAdress([FromRoute] RemoveFooterAddressCommandRequest request)
        {
            RemoveFooterAddressCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
