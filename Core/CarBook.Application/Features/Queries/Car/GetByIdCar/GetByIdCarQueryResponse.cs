using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Queries.Car.GetByIdCar
{
    public class GetByIdCarQueryResponse
    {
        public string Id { get; set; }
        public Guid BrandID { get; set; }
        public Domain.Entities.Brand Brand { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
        public List<CarDescription> CarDescriptions { get; set; }
        public List<CarPricing> CarPricings { get; set; }
    }
}