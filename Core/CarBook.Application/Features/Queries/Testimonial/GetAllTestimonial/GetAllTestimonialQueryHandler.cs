using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Testimonial.GetAllTestimonial
{
    public class GetAllTestimonialQueryHandler : IRequestHandler<GetAllTestimonialQueryRequest, GetAllTestimonialQueryResponse>
    {
        private readonly ITestimonialReadRepository _testimonialReadRepository;

        public GetAllTestimonialQueryHandler(ITestimonialReadRepository testimonialReadRepository)
        {
            _testimonialReadRepository = testimonialReadRepository;
        }

        public async Task<GetAllTestimonialQueryResponse> Handle(GetAllTestimonialQueryRequest request, CancellationToken cancellationToken)
        {
            var testimonials = _testimonialReadRepository.GetAll(false).ToList();
            return new()
            {
                Testimonials = testimonials,
            };
        }
    }
}
