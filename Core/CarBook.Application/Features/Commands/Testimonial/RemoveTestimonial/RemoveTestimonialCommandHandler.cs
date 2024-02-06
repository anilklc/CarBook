using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Testimonial.RemoveTestimonial
{
    public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommandRequest, RemoveTestimonialCommandResponse>
    {
        private readonly ITestimonialWriteRepository _testimonialWriteRepository;

        public RemoveTestimonialCommandHandler(ITestimonialWriteRepository testimonialWriteRepository)
        {
            _testimonialWriteRepository = testimonialWriteRepository;
        }

        public async Task<RemoveTestimonialCommandResponse> Handle(RemoveTestimonialCommandRequest request, CancellationToken cancellationToken)
        {
            await _testimonialWriteRepository.RemoveAsync(request.Id);
            await _testimonialWriteRepository.SaveAsync();
            return new();
        }
    }
}
