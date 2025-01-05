using Domain.Entities;
using Domain.Interfaces.IWarehouses;
using Infrastructure.dbContext;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly dbContextDatabase _context;

        public WarehouseRepository(dbContextDatabase context)
        {
            _context = context;
        }

        public double CheckWarehouseCapacity(int warehouseId)
        {
            var warehouse = _context.Warehouses.FirstOrDefault(w => w.Id == warehouseId);
            if (warehouse == null)
            {
                throw new Exception("Warehouse not found");
            }

            var totalOccupiedSpace = (_context.Shelfs.Where(s => s.WarehouseId == warehouseId).Count())*30;

            var remainingCapacity = warehouse.Area - totalOccupiedSpace;
            return remainingCapacity;
        }

        public WarehouseEntity CreateWarehouse(string name, double area, int cityId)
        {
            var city = _context.Citys.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                throw new Exception("City not found");
            }

            WarehouseEntity warehouse = new WarehouseEntity()
            {
                Name = name,
                Area = area,
                CityId = cityId,
                EmptySpace = area
            };

            _context.Warehouses.Add(warehouse);
            _context.SaveChanges();
            return warehouse;
        }

        public void DeleteWarehouse(int warehouseId)
        {
            var warehouse = _context.Warehouses.FirstOrDefault(w => w.Id == warehouseId);
            if (warehouse == null)
            {
                throw new Exception("Warehouse not found");
            }

            var shelves = _context.Shelfs.Where(s => s.WarehouseId == warehouseId).ToList();
            if (shelves.Count > 0)
            {
                throw new Exception("Please move the shelves before deleting the warehouse");
            }

            _context.Warehouses.Remove(warehouse);
            _context.SaveChanges();
        }

        public List<WarehouseEntity> GetAllWarehouses()
        {
            return _context.Warehouses.ToList();
        }

        public WarehouseEntity GetWarehouseById(int warehouseId)
        {
            return _context.Warehouses.FirstOrDefault(w => w.Id == warehouseId);
        }

        public IEnumerable<SerialEntity> GetWarehouseInventoryReport(int warehouseId)
        {
            var warehouse = _context.Warehouses.FirstOrDefault(w => w.Id == warehouseId);
            if (warehouse == null)
            {
                throw new Exception("Warehouse not found");
            }

            var inventoryReport = _context.SerialDocumnet
                .Where(sd => sd.Shelf.WarehouseId == warehouseId && sd.DocumnetId != 0)
                .Select(sd => sd.Serial)
                .ToList();
            List<SerialEntity> serials = new List<SerialEntity>();
            foreach (var item in inventoryReport)
            {
                int currentId = item.Id;
                int idCount = inventoryReport.Where(x => x.Id == currentId).Count();
                if (idCount%2==0)
                {
                    serials.Add(item);
                    //foreach(var serial in serials)
                    //{
                    //    inventoryReport.Remove(serial);
                    //}
                }
            }
            foreach (var item in serials)
            {
                inventoryReport.Remove(item);
            }

            return inventoryReport;
        }

        public void UpdateWarehouse(WarehouseEntity warehouse)
        {
            var existingWarehouse = _context.Warehouses.FirstOrDefault(w => w.Id == warehouse.Id);
            if (existingWarehouse == null)
            {
                throw new Exception("Warehouse not found");
            }

            var shelves = _context.Shelfs.Where(s => s.WarehouseId == warehouse.Id).ToList();
            bool canReduceArea = shelves.All(shelf => shelf.OccupiedSpace < warehouse.Area);

            if (warehouse.Area < existingWarehouse.Area && !canReduceArea)
            {
                throw new Exception("Please move the shelves before reducing the warehouse area");
            }

            existingWarehouse.Name = warehouse.Name;
            existingWarehouse.Area = warehouse.Area;
            existingWarehouse.CityId = warehouse.CityId;
            existingWarehouse.EmptySpace = warehouse.Area - shelves.Sum(s => s.OccupiedSpace);

            _context.SaveChanges();
        }
    }
}
