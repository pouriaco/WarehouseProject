using Application.Dtos.WarehouseDtos;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Jebheye_Moqavemat_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehouseService _warehouseService;

        public WarehouseController(WarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpPost("CreateWarehouse")]
        public WarehouseEntity CreateWarehouse(CRUDWarehouseDTO warehouseDto) =>
            _warehouseService.CreateWarehouse(warehouseDto.Name, warehouseDto.Area, warehouseDto.CityId);

        [HttpGet("GetAllWarehouses")]
        public List<WarehouseEntity> GetAllWarehouses() =>
            _warehouseService.GetAllWarehouses();

        [HttpGet("GetWarehouseById/{id}")]
        public WarehouseEntity GetWarehouseById(int id) =>
            _warehouseService.GetWarehouseById(id);

        [HttpPut("UpdateWarehouse")]
        public void UpdateWarehouse(UpdateWarehouseDTO warehouseDto) =>
            _warehouseService.UpdateWarehouse(new WarehouseEntity
            {
                Id = warehouseDto.Id,
                Name = warehouseDto.Name,
                Area = warehouseDto.Area,
                CityId = warehouseDto.CityId
            });

        [HttpDelete("DeleteWarehouse/{id}")]
        public void DeleteWarehouse(int id) =>
            _warehouseService.DeleteWarehouse(id);

        [HttpGet("CheckWarehouseCapacity/{id}")]
        public double CheckWarehouseCapacity(int id) =>
            _warehouseService.CheckWarehouseCapacity(id);

        [HttpGet("GetWarehouseInventoryReport/{id}")]
        public IEnumerable<SerialEntity> GetWarehouseInventoryReport(int id) =>
            _warehouseService.GetWarehouseInventoryReport(id);
    }
}
