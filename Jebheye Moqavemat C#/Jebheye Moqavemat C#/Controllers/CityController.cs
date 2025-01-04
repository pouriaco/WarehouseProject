using Application.Dtos.WarehouseDtos;
using Application.Services;
using Domain.Interfaces.IWarehouses;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly CityService _service;

        public CityController(ICityRepository repository)
        {
            _service = new CityService(repository);
        }

        [HttpPost("CreatCity")]
        public IActionResult CreateCity(CRUDCityDTO cityDto)
        {
            var city = _service.CreateCity(cityDto);
            return Ok(city);
        }

        [HttpGet("GetCityById{id}")]
        public IActionResult GetCityById(int id)
        {
            try
            {
                var city = _service.GetCityById(id);
                return Ok(city);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("City not found");
            }
        }

        [HttpPut("UpdateCity{id}")]
        public IActionResult UpdateCity(int id, CRUDCityDTO cityDto)
        {
            try
            {
                var city = _service.UpdateCity(id, cityDto);
                return Ok(city);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("City not found");
            }
        }

        [HttpDelete("DeleteCity{id}")]
        public IActionResult DeleteCity(int id)
        {
            try
            {
                var result = _service.DeleteCity(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("City not found");
            }
        }
    }
}
