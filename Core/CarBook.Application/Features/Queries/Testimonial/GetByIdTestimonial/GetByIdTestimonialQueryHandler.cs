using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Testimonial.GetByIdTestimonial
{
    public class GetByIdTestimonialQueryHandler : IRequestHandler<GetByIdTestimonialQueryRequest, GetByIdTestimonialQueryResponse>
    {
        private readonly ITestimonialReadRepository _testimonialReadRepository;

        public GetByIdTestimonialQueryHandler(ITestimonialReadRepository testimonialReadRepository)
        {
            _testimonialReadRepository = testimonialReadRepository;
        }

        public async Task<GetByIdTestimonialQueryResponse> Handle(GetByIdTestimonialQueryRequest request, CancellationToken cancellationToken)
        {
            var testimonial = await _testimonialReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Comment = testimonial.Comment,
                ImageUrl = testimonial.ImageUrl,
                Name = testimonial.Name,
                Title = testimonial.Title,
            };
        }
    }
}
