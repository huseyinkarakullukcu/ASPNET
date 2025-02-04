using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.SubscriberDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController(IGenericService<Subscriber> _subscriberService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var value = _subscriberService.TGetList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _subscriberService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _subscriberService.TDelete(id);
            return Ok("Subscriber Alanı Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateSubscriberDto createSubscriberDto)
        {
            var newValue = _mapper.Map<Subscriber>(createSubscriberDto);
            _subscriberService.TCreate(newValue);
            return Ok("Yeni Subscriber Alanı Eklendi.");
        }

        [HttpPut]
        public IActionResult Update(UpdateSubscriberDto updateSubscriberDto)
        {
            var value = _mapper.Map<Subscriber>(updateSubscriberDto);
            _subscriberService.TUpdate(value);
            return Ok("Subscriber Alanı Güncellendi");
        }
    }
}
