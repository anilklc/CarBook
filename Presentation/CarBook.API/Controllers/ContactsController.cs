using CarBook.Application.Features.Commands.Contact.CreateContact;
using CarBook.Application.Features.Commands.Contact.RemoveContact;
using CarBook.Application.Features.Commands.Contact.UpdateContact;
using CarBook.Application.Features.Queries.Contact.GetAllContact;
using CarBook.Application.Features.Queries.Contact.GetByIdContact;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAbout()
        {
            GetAllContactQueryResponse response = await _mediator.Send(new GetAllContactQueryRequest());
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAbout([FromRoute] GetByIdContactQueryRequest request)
        {
            GetByIdContactQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAbout([FromQuery] CreateContactCommandRequest request)
        {
            CreateContactCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAbout([FromQuery] UpdateContactCommandRequest request)
        {
            UpdateContactCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveAbout([FromRoute] RemoveContactCommandRequest request)
        {
            RemoveContactCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
