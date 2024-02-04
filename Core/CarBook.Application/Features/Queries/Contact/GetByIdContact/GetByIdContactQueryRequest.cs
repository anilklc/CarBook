using MediatR;

namespace CarBook.Application.Features.Queries.Contact.GetByIdContact
{
    public class GetByIdContactQueryRequest : IRequest<GetByIdContactQueryResponse>
    {
        public string Id { get; set; }
    }
}