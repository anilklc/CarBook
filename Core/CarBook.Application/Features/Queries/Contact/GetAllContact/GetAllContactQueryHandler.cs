using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Contact.GetAllContact
{
    public class GetAllContactQueryHandler : IRequestHandler<GetAllContactQueryRequest, GetAllContactQueryResponse>
    {
        private readonly IContactReadRepository _contactReadRepository;

        public GetAllContactQueryHandler(IContactReadRepository contactReadRepository)
        {
            _contactReadRepository = contactReadRepository;
        }

        public async Task<GetAllContactQueryResponse> Handle(GetAllContactQueryRequest request, CancellationToken cancellationToken)
        {
            var contacts = _contactReadRepository.GetAll(false).ToList();
            return new()
            {
                Contacts = contacts,
            };
        }
    }
}
