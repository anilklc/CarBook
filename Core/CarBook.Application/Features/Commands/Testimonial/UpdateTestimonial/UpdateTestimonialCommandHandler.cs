using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Testimonial.UpdateTestimonial
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommandRequest, UpdateTestimonialCommandResponse>
    {
        private readonly ITestimonialReadRepository _testimonialReadRepository;
        private readonly ITestimonialWriteRepository _testimonialWriteRepository;

        public UpdateTestimonialCommandHandler(ITestimonialReadRepository testimonialReadRepository, ITestimonialWriteRepository testimonialWriteRepository)
        {
            _testimonialReadRepository = testimonialReadRepository;
            _testimonialWriteRepository = testimonialWriteRepository;
        }

        public async Task<UpdateTestimonialCommandResponse> Handle(UpdateTestimonialCommandRequest request, CancellationToken cancellationToken)
        {
            var testimonial = await _testimonialReadRepository.GetByIdAsync(request.Id);
            testimonial.Title = request.Title;
            testimonial.Comment = request.Comment;
            testimonial.ImageUrl = request.ImageUrl;
            testimonial.Name = request.Name;
            await _testimonialWriteRepository.SaveAsync();
            return new();
        }
    }
}
