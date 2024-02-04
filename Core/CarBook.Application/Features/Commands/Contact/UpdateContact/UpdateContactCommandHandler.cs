using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Contact.UpdateContact
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommandRequest, UpdateContactCommandResponse>
    {
        private readonly IContactReadRepository _contactReadRepository;
        private readonly IContactWriteRepository _contactWriteRepository;

        public UpdateContactCommandHandler(IContactReadRepository contactReadRepository, IContactWriteRepository contactWriteRepository)
        {
            _contactReadRepository = contactReadRepository;
            _contactWriteRepository = contactWriteRepository;
        }

        public async Task<UpdateContactCommandResponse> Handle(UpdateContactCommandRequest request, CancellationToken cancellationToken)
        {
            var contact = await _contactReadRepository.GetByIdAsync(request.Id);
            contact.Subject = request.Subject;
            contact.Message = request.Message;
            contact.Name = request.Name;
            contact.Email = request.Email;
            contact.SendDate = DateTime.Now;
            await _contactWriteRepository.SaveAsync();
            return new();

        }
    }
}
