using AutoMapper;
using BusinessLayer.Abstract;
using DtoLater.FeatureDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalFoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetAll());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.TGetById(id);

            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            _featureService.TAdd(new Feature()
            {
                Title = createFeatureDto.Title,
                Description = createFeatureDto.Description
            });

            return Ok("Öne Çıkan Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetById(id);
            _featureService.TDelete(value);

            return Ok("Öne Çıkan Kaldırıldı!");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _featureService.TUpdate(new Feature()
            {
                FeatureId = updateFeatureDto.FeatureId,
                Title = updateFeatureDto.Title,
                Description = updateFeatureDto.Description
            });

            return Ok("Öne Çıkan Güncellendi!");
        }

    }
}
