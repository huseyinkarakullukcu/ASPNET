using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseCategoryDtos;
using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoriesController(IGenericService<CourseCategory> _courseCategoryService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _courseCategoryService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _courseCategoryService.TGetById(id);
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseCategoryService.TDelete(id);
            return Ok("Course Kategori Alanı Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateCourseCategoryDto createCourseCategoryDto)
        {
            var newValue = _mapper.Map<CourseCategory>(createCourseCategoryDto);
            _courseCategoryService.TCreate(newValue);
            return Ok("Course Kategori Eklendi");
        }
        [HttpPut]
        public IActionResult Update(UpdateCourseCategoryDto updateCategoryCourseDto)
        {
            var value = _mapper.Map<CourseCategory>(updateCategoryCourseDto);
            _courseCategoryService.TUpdate(value);
            return Ok("Course Kategori Alanı Güncellendi");
        }
    }
}
