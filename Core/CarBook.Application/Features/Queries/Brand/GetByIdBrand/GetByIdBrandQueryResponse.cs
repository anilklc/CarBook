namespace CarBook.Application.Features.Queries.Brand.GetByIdBrand
{
    public class GetByIdBrandQueryResponse
    {
        public string Name { get; set; }
        public List<Domain.Entities.Car> Cars { get; set; }
    }
}