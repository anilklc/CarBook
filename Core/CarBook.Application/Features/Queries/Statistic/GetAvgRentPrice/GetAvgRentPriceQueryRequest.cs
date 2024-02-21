using CarBook.Application.Interfaces.Repositories;
using MediatR;

namespace CarBook.Application.Features.Queries.Statistic.GetAvgRentPrice
{
    public class GetAvgRentPriceQueryRequest : IRequest<GetAvgRentPriceQueryResponse>
    {
    }
}