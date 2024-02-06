using MediatR;

namespace CarBook.Application.Features.Commands.Testimonial.CreateTestimonial
{
    public class CreateTestimonialCommandRequest : IRequest<CreateTestimonialCommandResponse>
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}