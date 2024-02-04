using MediatR;

namespace CarBook.Application.Features.Queries.Brand.GetByIdBrand
{
    public class GetByIdBrandQueryRequest : IRequest<GetByIdBrandQueryResponse>
    {
        public string Id { get; set; }
    }
}