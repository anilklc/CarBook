using CarBook.Application.Features.Commands.Reservation.CreateReservation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationCommandRequest request)
        {
            CreateReservationCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
