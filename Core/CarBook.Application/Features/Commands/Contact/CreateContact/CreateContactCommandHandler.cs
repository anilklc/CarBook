using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Contact.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommandRequest, CreateContactCommandResponse>
    {
        private readonly IContactWriteRepository _contactWriteRepository;

        public CreateContactCommandHandler(IContactWriteRepository contactWriteRepository)
        {
            _contactWriteRepository = contactWriteRepository;
        }

        public async Task<CreateContactCommandResponse> Handle(CreateContactCommandRequest request, CancellationToken cancellationToken)
        {
            await _contactWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Email = request.Email,
                Message = request.Message,
                SendDate = request.SendDate,
                Subject = request.Subject,
            });
            await _contactWriteRepository.SaveAsync();
            return new();
        }
    }
}
