using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.BannerDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IGenericService<Banner> _bannerServices, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var value = _bannerServices.TGetList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _bannerServices.TGetById(id);
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bannerServices.TDelete(id);
            return Ok("Banner Alanı Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateBannerDto createBannerDto)
        {
            var newValue = _mapper.Map<Banner>(createBannerDto);
            _bannerServices.TCreate(newValue);
            return Ok("Banner Alanı Eklendi");
        }
        [HttpPut]
        public IActionResult Update(UpdateBannerDto updateBannerDto)
        {
             var value = _mapper.Map<Banner>(updateBannerDto);
            _bannerServices.TUpdate(value);
            return Ok("Banner Alanı Güncellendi");
        }
    }
}
