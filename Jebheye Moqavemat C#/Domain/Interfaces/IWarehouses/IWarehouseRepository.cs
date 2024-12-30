using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IWarehouses
{
    internal interface IWarehouseRepository
    {
      /* C */ public WarehouseEntity CreateWarehouse(string name, double area, int cityId);
      /* R */ public int GetWarehouseById(int warehouseId);
      /* U */ public int UpdateWarehouse(string name, double area, int cityId);
      /* D */ public bool DeleteWarehouse(int warehouseId);
  
       public double CheckWarehouseCapacity(int warehouseId); // بررسی و محاسبه ظرفیت باقی‌مانده یک انبار
       public IEnumerable<SerialEntity> GetWarehouseInventoryReport(int warehouseId); // گزارش موجودی انبار شامل لیستی از محصولات و تعداد آن‌ها
      // public bool TransferProduct(int serialNumber, int fromWarehouseId, int toWarehouseId , int forShelfId , int toShelfId); // انتقال کالا از یک انبار به انبار دیگر
    }
}
