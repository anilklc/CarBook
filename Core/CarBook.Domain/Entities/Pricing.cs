using CarBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Pricing : BaseEntity
    {
        public string Name { get; set; }
        public List<CarPricing> CarPricings { get; set; }
    }
}
