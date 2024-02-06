using MediatR;

namespace CarBook.Application.Features.Commands.Testimonial.UpdateTestimonial
{
    public class UpdateTestimonialCommandRequest : IRequest<UpdateTestimonialCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }

    }
}