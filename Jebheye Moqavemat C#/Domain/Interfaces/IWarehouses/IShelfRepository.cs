using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IWarehouses
{
    public interface IShelfRepository
    {
     /* C */  public ShelfEntity CreateShelf(int occupiedSpace , int levels , int warehouseId);
     /* U */  public ShelfEntity UpdateShelf(int occupiedSpace, int levels, int shelfId, int newWarehouseId);
     /* D */  public bool DeleteShelf(int shelfId);
              public ShelfEntity GetShelfById(int id);
              public List<ShelfEntity> GetShelvesByWarehouse(int warehouseId); // دریافت لیست قفسه‌های موجود در یک انبار
    }
}
