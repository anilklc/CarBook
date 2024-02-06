using MediatR;

namespace CarBook.Application.Features.Commands.Testimonial.RemoveTestimonial
{
    public class RemoveTestimonialCommandRequest : IRequest<RemoveTestimonialCommandResponse>
    {
        public string Id { get; set; }
    }
}