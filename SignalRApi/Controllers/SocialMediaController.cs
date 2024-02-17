using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

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

    }
}
