using AutoMapper;
using BusinessLayer.Abstract;
using DtoLater.TestimonialDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalFoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetAll());

            return Ok(values);
        }

        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);

            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                TestimonialName = createTestimonialDto.TestimonialName,
                Title = createTestimonialDto.Title,
                Commend = createTestimonialDto.Commend,
                ImageUrl = createTestimonialDto.ImageUrl,
                TestimonialStatus = createTestimonialDto.TestimonialStatus
            });

            return Ok("Müşteri Yorumu Eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);

            return Ok("Müşteri Yorumu Kaldırıldı!");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(new Testimonial()
            {
                TestimonialId = updateTestimonialDto.TestimonialId,
                TestimonialName = updateTestimonialDto.TestimonialName,
                Title = updateTestimonialDto.Title,
                Commend = updateTestimonialDto.Commend,
                ImageUrl = updateTestimonialDto.ImageUrl,
                TestimonialStatus = updateTestimonialDto.TestimonialStatus
            });

            return Ok("Müşteri Yorumu Güncellendi.");
        }

    }
}
