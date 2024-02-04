using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.Contact.RemoveContact
{
    public class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommandRequest, RemoveContactCommandResponse>
    {
        private readonly IContactWriteRepository _contactWriteRepository;

        public RemoveContactCommandHandler(IContactWriteRepository contactWriteRepository)
        {
            _contactWriteRepository = contactWriteRepository;
        }

        public async Task<RemoveContactCommandResponse> Handle(RemoveContactCommandRequest request, CancellationToken cancellationToken)
        {
            await _contactWriteRepository.RemoveAsync(request.Id);
            await _contactWriteRepository.SaveAsync();
            return new();
        }
    }
}
