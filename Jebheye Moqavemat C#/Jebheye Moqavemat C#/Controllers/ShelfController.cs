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
    public class ShelfController : ControllerBase
    {
        private readonly ShelfService _service;

        public ShelfController(IShelfRepository service)
        {
            _service = new ShelfService(service);
        }

        [HttpPost("CreateShelf")]
        public IActionResult PostShelf(CRUDShelfDTO shelfDTO)
        {
            var result = _service.CreateShelf(shelfDTO);
            if (result == "The creation was successful.")
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetShelvesByWarehouse/{warehouseId}")]
        public ActionResult<IEnumerable<ShelfEntity>> GetShelvesByWarehouse(int warehouseId)
        {
            var shelves = _service.GetShelvesByWarehouse(warehouseId);
            return Ok(shelves);
        }

        [HttpGet("GetShelf{id}")]
        public ActionResult<ShelfEntity> GetShelf(int id)
        {
            var shelf = _service.GetShelfById(id);
            if (shelf == null)
            {
                return NotFound();
            }

            return Ok(shelf);
        }

        [HttpPut("UpdateShelf/{shelfId}/{newWarehouseId}")]
        public IActionResult PutShelf(int shelfId, int newWarehouseId)
        {
            var result = _service.UpdateShelf(shelfId, newWarehouseId);
            if (result == "The update was successful.")
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("DeleteShelf/{id}")]
        public IActionResult DeleteShelf(int id)
        {
            var result = _service.DeleteShelf(id);
            if (result == "The deletion was successful.")
            {
                return Ok(result);
            }
            else if (result == "Please move your products to another shelf first.")
            {
                return BadRequest(result);
            }
            else
            {
                return NotFound(result);
            }
        }


    }
}
