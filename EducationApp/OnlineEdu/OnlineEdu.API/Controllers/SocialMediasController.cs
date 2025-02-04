using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.SocialMediaDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController(IGenericService<SocialMedia> _socialMediaService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var value = _socialMediaService.TGetList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _socialMediaService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _socialMediaService.TDelete(id);
            return Ok("Social Media Alanı Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateSocialMediaDto createSocialMediaDto)
        {
            var newValue = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TCreate(newValue);
            return Ok("Yeni Social Media Alanı Eklendi.");
        }

        [HttpPut]
        public IActionResult Update(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.TUpdate(value);
            return Ok("Social Media Alanı Güncellendi");
        }
    }
}
