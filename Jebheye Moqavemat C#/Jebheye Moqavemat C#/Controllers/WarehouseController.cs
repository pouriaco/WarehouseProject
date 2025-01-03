using Application.Dtos.WarehouseDtos;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces.IWarehouses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Jebheye_Moqavemat_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private WarehouseService _warehouseService;

        public WarehouseController(IWarehouseRepository warehouseService)
        {
            _warehouseService = new WarehouseService(warehouseService);
        }


        [HttpPost("CreateWarehouse")]
        public IActionResult CreateWarehouse(CRUDWarehouseDTO warehouseDto)
        {
            try
            {
                var warehouse = _warehouseService.CreateWarehouse(warehouseDto.Name, warehouseDto.Area, warehouseDto.CityId);
                return Ok(warehouse);
            }
            catch (Exception ex)
            {
                if (ex.Message == "City not found")
                {
                    return NotFound(ex.Message);
                }
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllWarehouse")]
        public List<WarehouseEntity> GetAllWarehouses()
        {
            return _warehouseService.GetAllWarehouses();
        }

        [HttpGet("GetWarehouseById{id}")]
        public ActionResult<WarehouseEntity> GetWarehouseById(int id)
        {
            var warehouse = _warehouseService.GetWarehouseById(id);
            if (warehouse == null)
            {
                return NotFound("Warehouse is not found");
            }
            return Ok(warehouse);
        }

        [HttpPut("UpdateWarehouse")]
        public IActionResult UpdateWarehouse(UpdateWarehouseDTO warehouseDto)
        {
            try
            {
                var warehouse = new WarehouseEntity
                {
                    Id = warehouseDto.Id,
                    Name = warehouseDto.Name,
                    Area = warehouseDto.Area,
                    CityId = warehouseDto.CityId
                };
                _warehouseService.UpdateWarehouse(warehouse);
                return Ok("Warehouse updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteWarehouse/{id}")]
        public IActionResult DeleteWarehouse(int id)
        {
            try
            {
                _warehouseService.DeleteWarehouse(id);
                return Ok("Warehouse deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("CheckWarehouseCapacity/{id}")]
        public IActionResult CheckWarehouseCapacity(int id)
        {
            try
            {
                var remainingCapacity = _warehouseService.CheckWarehouseCapacity(id);
                return Ok(remainingCapacity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetWarehouseInventoryReport/{id}")]
        public IActionResult GetWarehouseInventoryReport(int id)
        {
            try
            {
                var inventoryReport = _warehouseService.GetWarehouseInventoryReport(id);
                return Ok(inventoryReport);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}