using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalFoodWebUI.Dtos.FeatureDtos
{
    public class ResultFeatureDto
    {
        public int FeatureId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
