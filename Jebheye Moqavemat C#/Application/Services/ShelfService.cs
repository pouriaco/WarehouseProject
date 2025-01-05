using Application.Dtos.WarehouseDtos;
using Domain.Entities;
using Domain.Interfaces.IWarehouses;
using System.Collections.Generic;

namespace Application.Services
{
    public class ShelfService
    {
        private readonly IShelfRepository _shelfRepository;

        public ShelfService(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }

        public string CreateShelf(CRUDShelfDTO shelfDTO)
        {
            try
            {
                _shelfRepository.CreateShelf(shelfDTO.NumberOfShelves, shelfDTO.WarehouseId);
                return "The creation was successful.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateShelf(int shelfId, int newWarehouseId, CRUDShelfDTO shelfDTO)
        {
            try
            {
                _shelfRepository.UpdateShelf(shelfId, newWarehouseId, shelfDTO.NumberOfShelves);
                return "The update was successful.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteShelf(int shelfId)
        {
            try
            {
                if (_shelfRepository.DeleteShelf(shelfId))
                {
                    return "The deletion was successful.";
                }
                return "Shelf not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<ShelfEntity> GetShelvesByWarehouse(int warehouseId)
        {
            return _shelfRepository.GetShelvesByWarehouse(warehouseId);
        }

        public ShelfEntity GetShelfById(int id)
        {
            return _shelfRepository.GetShelfById(id);
        }

        public List<ShelfEntity> GetAllShelves()
        {
            return _shelfRepository.GetAllShelves();
        }
    }
}
