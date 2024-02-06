﻿using CarBook.Application.Features.Commands.About.CreateAbout;
using CarBook.Application.Features.Commands.About.RemoveAbout;
using CarBook.Application.Features.Commands.About.UpdateAbout;
using CarBook.Application.Features.Commands.Service.CreateService;
using CarBook.Application.Features.Commands.Service.RemoveService;
using CarBook.Application.Features.Commands.Service.UpdateService;
using CarBook.Application.Features.Queries.About.GetAllAbout;
using CarBook.Application.Features.Queries.About.GetByIdAbout;
using CarBook.Application.Features.Queries.Service.GetAllService;
using CarBook.Application.Features.Queries.Service.GetByIdService;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllService()
        {
            GetAllServiceQueryResponse response = await _mediator.Send(new GetAllServiceQueryRequest());
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdService([FromRoute] GetByIdServiceQueryRequest request)
        {
            GetByIdServiceQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateService([FromQuery] CreateServiceCommandRequest request)
        {
            CreateServiceCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateService([FromQuery] UpdateServiceCommandRequest request)
        {
            UpdateServiceCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveService([FromRoute] RemoveServiceCommandRequest request)
        {
            RemoveServiceCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
