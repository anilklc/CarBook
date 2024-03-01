using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarFeature
{
    public class ResultCarFeatureByCarIdDto
    {
        public string CarFeatureID { get; set; }
        public string FeatureID { get; set; }
        public string FeatureName { get; set; }
        public bool Available { get; set; }
    }
}
