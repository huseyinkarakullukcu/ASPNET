﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IGenericService<Blog> _blogService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _blogService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _blogService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _blogService.TDelete(id);
            return Ok("Blog Alanı Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateBlogDto createBlogDto)
        {
            var newValues = _mapper.Map<Blog>(createBlogDto);
            _blogService.TCreate(newValues);
            return Ok("Yeni Blog Alanı Eklendi.");
        }

        [HttpPut]
        public IActionResult Update(UpdateBlogDto updateBlogDto)
        {
            var value = _mapper.Map<Blog>(updateBlogDto);
            _blogService.TUpdate(value);
            return Ok("Blog Alanı Güncellendi.");
        }

    }
}
