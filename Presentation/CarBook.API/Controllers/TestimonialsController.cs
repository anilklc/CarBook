using CarBook.Application.Features.Commands.Testimonial.CreateTestimonial;
using CarBook.Application.Features.Commands.Testimonial.RemoveTestimonial;
using CarBook.Application.Features.Commands.Testimonial.UpdateTestimonial;
using CarBook.Application.Features.Queries.Testimonial.GetAllTestimonial;
using CarBook.Application.Features.Queries.Testimonial.GetByIdTestimonial;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllTestimonial()
        {
            GetAllTestimonialQueryResponse response = await _mediator.Send(new GetAllTestimonialQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdTestimonial([FromRoute] GetByIdTestimonialQueryRequest request)
        {
            GetByIdTestimonialQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTestimonial([FromBody] CreateTestimonialCommandRequest request)
        {
            CreateTestimonialCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateTestimonial([FromBody] UpdateTestimonialCommandRequest request)
        {
            UpdateTestimonialCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveTestimonial(string Id)
        {
            RemoveTestimonialCommandRequest request = new RemoveTestimonialCommandRequest { Id = Id };
            RemoveTestimonialCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
