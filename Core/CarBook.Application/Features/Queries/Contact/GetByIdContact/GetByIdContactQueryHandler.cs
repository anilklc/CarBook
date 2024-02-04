using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Contact.GetByIdContact
{
    public class GetByIdContactQueryHandler : IRequestHandler<GetByIdContactQueryRequest, GetByIdContactQueryResponse>
    {
        private readonly IContactReadRepository _contactReadRepository;

        public GetByIdContactQueryHandler(IContactReadRepository contactReadRepository)
        {
            _contactReadRepository = contactReadRepository;
        }

        public async Task<GetByIdContactQueryResponse> Handle(GetByIdContactQueryRequest request, CancellationToken cancellationToken)
        {
            var contact = await _contactReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Email = contact.Email,
                Message = contact.Message,
                Name = contact.Name,
                SendDate = contact.SendDate,
                Subject = contact.Subject,
            };
        }
    }
}
