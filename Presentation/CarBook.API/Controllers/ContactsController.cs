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
        public async Task<IActionResult> GetAllContact()
        {
            GetAllContactQueryResponse response = await _mediator.Send(new GetAllContactQueryRequest());
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdContact([FromRoute] GetByIdContactQueryRequest request)
        {
            GetByIdContactQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateContact([FromBody]CreateContactCommandRequest request)
        {
            CreateContactCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateContact([FromQuery] UpdateContactCommandRequest request)
        {
            UpdateContactCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveContact([FromRoute] RemoveContactCommandRequest request)
        {
            RemoveContactCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
