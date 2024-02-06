using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Testimonial.CreateTestimonial
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommandRequest, CreateTestimonialCommandResponse>
    {
        private readonly ITestimonialWriteRepository _testimonialWriteRepository;

        public CreateTestimonialCommandHandler(ITestimonialWriteRepository testimonialWriteRepository)
        {
            _testimonialWriteRepository = testimonialWriteRepository;
        }

        public async Task<CreateTestimonialCommandResponse> Handle(CreateTestimonialCommandRequest request, CancellationToken cancellationToken)
        {
            await _testimonialWriteRepository.AddAsync(new()
            {
                Comment = request.Comment,
                ImageUrl = request.ImageUrl,
                Name = request.Name,
                Title = request.Title
            });
            await _testimonialWriteRepository.SaveAsync();
            return new();
        }
    }
}
