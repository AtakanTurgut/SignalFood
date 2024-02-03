using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLater.TestimonialDto
{
    public class CreateTestimonialDto
    {
        public string? TestimonialName { get; set; }
        public string? Title { get; set; }
        public string? Commend { get; set; }
        public string? ImageUrl { get; set; }
        public bool TestimonialStatus { get; set; }
    }
}
