using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.About.UpdateAbout
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommandRequest, UpdateAboutCommandResponse>
    {
        private readonly IAboutReadRepository _aboutReadRepository;
        private readonly IAboutWriteRepository _aboutWriteRepository;

        public UpdateAboutCommandHandler(IAboutReadRepository aboutReadRepository, IAboutWriteRepository aboutWriteRepository)
        {
            _aboutReadRepository = aboutReadRepository;
            _aboutWriteRepository = aboutWriteRepository;
        }

        public async Task<UpdateAboutCommandResponse> Handle(UpdateAboutCommandRequest request, CancellationToken cancellationToken)
        {
            var about = await _aboutReadRepository.GetByIdAsync(request.Id);
            about.Title = request.Title;
            about.Description = request.Description;
            about.ImageUrl = request.ImageUrl;
            await _aboutWriteRepository.SaveAsync();
            return new(); 
        }
    }
}
