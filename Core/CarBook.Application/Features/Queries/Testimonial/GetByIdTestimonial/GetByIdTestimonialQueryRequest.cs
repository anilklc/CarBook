using MediatR;

namespace CarBook.Application.Features.Queries.Testimonial.GetByIdTestimonial
{
    public class GetByIdTestimonialQueryRequest : IRequest<GetByIdTestimonialQueryResponse>
    {
        public string Id { get; set; }
    }
}