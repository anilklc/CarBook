using MediatR;

namespace CarBook.Application.Features.Queries.CarDescription
{
    public class GetCarDescriptionWithByCarIdRequest : IRequest<GetCarDescriptionWithByCarIdResponse>
    {
        public Guid Id { get; set; }
    }
}