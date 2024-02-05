using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalFoodWebUI.Dtos.TestimonialDtos
{
    public class GetTestimonialDto
    {
        public int TestimonialId { get; set; }
        public string? TestimonialName { get; set; }
        public string? Title { get; set; }
        public string? Commend { get; set; }
        public string? ImageUrl { get; set; }
        public bool TestimonialStatus { get; set; }
    }
}
