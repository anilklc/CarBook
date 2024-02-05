using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Queries.Service.GetByIdService
{
    public class GetByIdServiceQueryResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}