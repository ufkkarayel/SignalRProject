using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _service;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_service.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            _service.TAdd(new SocialMedia()
            {
                Icon = createSocialMediaDto.Icon,
                Title = createSocialMediaDto.Title,
                Url = createSocialMediaDto.Url
            });
            return Ok("Sosyal medya bilgisi kaydedildi");
        }
        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value=_service.TGetByID(id);
            _service.TDelete(value);
            return Ok("Sosyal medya bilgisi silindi");
        }
        [HttpGet("GetSocialMedia")]
        public  IActionResult GetSocialMedia(int id)
        {
            var value =_service.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _service.TUpdate(new SocialMedia()
            {
                Icon = updateSocialMediaDto.Icon,
                Title = updateSocialMediaDto.Title,
                Url = updateSocialMediaDto.Url,
                SocialMediaID = updateSocialMediaDto.SocialMediaID
            });
            return Ok("Sosyal medya bilgisi güncellendi");
        }

    }
}
