using MediatR;

namespace CarBook.Application.Features.Queries.Banner.GetByIdBanner
{
    public class GetByIdBannerQueryRequest : IRequest<GetByIdBannerQueryResponse>
    {
        public string Id { get; set; }
    }
}