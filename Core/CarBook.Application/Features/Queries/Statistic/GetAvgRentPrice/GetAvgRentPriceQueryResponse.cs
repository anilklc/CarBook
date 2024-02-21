namespace CarBook.Application.Features.Queries.Statistic.GetAvgRentPrice
{
    public class GetAvgRentPriceQueryResponse
    {
        public decimal Daily { get; set; }
        public decimal Monthly { get; set; }
        public decimal Weekly { get; set; }
    }
}