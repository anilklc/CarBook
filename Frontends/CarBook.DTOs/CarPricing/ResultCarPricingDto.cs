using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarPricing
{
    public class ResultCarPricingDto
    {
        public string Id { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public Guid PricingId { get; set; }
        public string PricingName { get; set; }
        public decimal PricingAmount { get; set; }

    }

}
