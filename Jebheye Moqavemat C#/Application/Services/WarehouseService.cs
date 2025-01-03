using Domain.Entities;
using Domain.Interfaces.IWarehouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WarehouseService
    {
        private IWarehouseRepository _warehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public WarehouseEntity CreateWarehouse(string name, double area, int cityId)
        {
            return _warehouseRepository.CreateWarehouse(name, area, cityId);
        }
        public List<WarehouseEntity> GetAllWarehouses()
        {
            return _warehouseRepository.GetAllWarehouses();
        }

        public WarehouseEntity GetWarehouseById(int warehouseId)
        {
            return _warehouseRepository.GetWarehouseById(warehouseId);
        }

        public void UpdateWarehouse(WarehouseEntity warehouse)
        {
            _warehouseRepository.UpdateWarehouse(warehouse);
        }

        public void DeleteWarehouse(int warehouseId)
        {
            _warehouseRepository.DeleteWarehouse(warehouseId);
        }

        public double CheckWarehouseCapacity(int warehouseId)
        {
            return _warehouseRepository.CheckWarehouseCapacity(warehouseId);
        }

        public IEnumerable<SerialEntity> GetWarehouseInventoryReport(int warehouseId)
        {
            return _warehouseRepository.GetWarehouseInventoryReport(warehouseId);
        }

    }
}
