using Application.Dtos.WarehouseDtos;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly CityService _service;

        public CityController(CityService service)
        {
            _service = service;
        }

        [HttpPost("CreateCity")]
        public CityEntity CreateCity(CRUDCityDTO cityDto) =>
            _service.CreateCity(cityDto);

        [HttpGet("GetCityById/{id}")]
        public CityEntity GetCityById(int id) =>
            _service.GetCityById(id);

        [HttpPut("UpdateCity/{id}")]
        public CityEntity UpdateCity(int id, CRUDCityDTO cityDto) =>
            _service.UpdateCity(id, cityDto);

        [HttpDelete("DeleteCity/{id}")]
        public bool DeleteCity(int id) =>
            _service.DeleteCity(id);
    }
}
