using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.Statistics
{
    public class ResultStatisticsDto
    {
        public int carCount { get; set; }
        public int locationCount { get; set; }
        public int authorCount { get; set; }
        public int blogCount { get; set; }
        public int brandCount { get; set; }
        public decimal daily { get; set; }
        public decimal weekly { get; set; }
        public decimal monthly { get; set; }
        public int km { get; set; }
        public int gasoline { get; set; }
        public int electric { get; set; }
        public string brandName { get; set; }
    }
}
