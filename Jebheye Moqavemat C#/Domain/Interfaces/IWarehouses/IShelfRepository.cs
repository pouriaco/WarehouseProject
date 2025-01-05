using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.IWarehouses
{
    public interface IShelfRepository
    {
        /* C */ public ShelfEntity CreateShelf(int numberOfShelves, int warehouseId);
        /* R */ public ShelfEntity GetShelfById(int id);
        /* U */ public ShelfEntity UpdateShelf(int shelfId, int newWarehouseId, int numberOfShelves);
        /* D */ public bool DeleteShelf(int shelfId);
        public List<ShelfEntity> GetAllShelves();
        public List<ShelfEntity> GetShelvesByWarehouse(int warehouseId);
    }
}
