﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.DTOs
{
    public class CarAndPricingDayDto
    {
        public string Id { get; set; }
        public Guid BrandID { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
        public Guid PricingId { get; set; }
        public string PricingName { get; set; }
        public decimal PricingAmount { get; set; }
    }
}
