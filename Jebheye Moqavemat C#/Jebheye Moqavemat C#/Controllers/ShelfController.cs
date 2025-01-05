using Application.Dtos.WarehouseDtos;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Jebheye_Moqavemat_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfController : ControllerBase
    {
        private readonly ShelfService _service;

        public ShelfController(ShelfService service)
        {
            _service = service;
        }

        [HttpGet("GetShelvesByWarehouse/{warehouseId}")]
        public List<ShelfEntity> GetShelvesByWarehouse(int warehouseId) =>
            _service.GetShelvesByWarehouse(warehouseId);

        [HttpGet("{id}")]
        public ShelfEntity GetShelf(int id) =>
            _service.GetShelfById(id);

        [HttpPost("CreateShelf")]
        public string CreateShelf(CRUDShelfDTO shelfDTO) =>
            _service.CreateShelf(shelfDTO);

        [HttpPut("UpdateShelf/{shelfId}/{newWarehouseId}")]
        public string UpdateShelf(int shelfId, int newWarehouseId, CRUDShelfDTO shelfDTO) =>
            _service.UpdateShelf(shelfId, newWarehouseId, shelfDTO);

        [HttpDelete("DeleteShelf/{id}")]
        public string DeleteShelf(int id) =>
            _service.DeleteShelf(id);

        [HttpGet("GetAllShelves")]
        public List<ShelfEntity> GetAllShelves() =>
            _service.GetAllShelves();
    }
}
