using Domain.Entities;
using Domain.Interfaces.IWarehouses;
using Infrastructure.dbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class ShelfRepository : IShelfRepository
    {
        private readonly dbContextDatabase _context;

        public ShelfRepository(dbContextDatabase context)
        {
            _context = context;
        }

        public ShelfEntity CreateShelf(int numberOfShelves, int warehouseId)
        {
            var warehouse = _context.Warehouses.FirstOrDefault(w => w.Id == warehouseId);
            if (warehouse == null)
            {
                throw new Exception("Warehouse not found");
            }

            int occupiedSpacePerShelf = 150;
            int levelsPerShelf = 5;
            int totalOccupiedSpace = numberOfShelves * 30;

            var totalOccupiedSpaceInWarehouse = _context.Shelfs
                .Where(s => s.WarehouseId == warehouseId)
                .Sum(s => s.OccupiedSpace);
            var availableSpace = warehouse.EmptySpace - totalOccupiedSpace;

            if (totalOccupiedSpace > availableSpace)
            {
                throw new Exception("Not enough space in the warehouse");
            }

            for (int i = 0; i < numberOfShelves; i++)
            {
                var shelf = new ShelfEntity
                {
                    OccupiedSpace = occupiedSpacePerShelf,
                    Levels = levelsPerShelf,
                    WarehouseId = warehouseId
                };
                _context.Shelfs.Add(shelf);
            }
            _context.SaveChanges();

            warehouse.EmptySpace = availableSpace;
            _context.SaveChanges();

            return new ShelfEntity();
        }

        public ShelfEntity UpdateShelf(int shelfId, int newWarehouseId, int numberOfShelves)
        {
            var shelf = _context.Shelfs.FirstOrDefault(s => s.Id == shelfId);
            if (shelf == null)
            {
                throw new Exception("Shelf not found");
            }

            var currentWarehouse = _context.Warehouses.FirstOrDefault(w => w.Id == shelf.WarehouseId);
            var newWarehouse = _context.Warehouses.FirstOrDefault(w => w.Id == newWarehouseId);
            if (newWarehouse == null)
            {
                throw new Exception("New warehouse not found");
            }

            int occupiedSpacePerShelf = 30;
            int totalOccupiedSpace = numberOfShelves * occupiedSpacePerShelf;

            var totalOccupiedSpaceInNewWarehouse = _context.Shelfs
                .Where(s => s.WarehouseId == newWarehouseId)
                .Sum(s => s.OccupiedSpace);
            var availableSpaceInNewWarehouse = newWarehouse.Area - totalOccupiedSpaceInNewWarehouse;

            if (totalOccupiedSpace > availableSpaceInNewWarehouse)
            {
                throw new Exception("Not enough space in the new warehouse");
            }

            currentWarehouse.EmptySpace += shelf.OccupiedSpace;

            newWarehouse.EmptySpace -= shelf.OccupiedSpace;

            shelf.WarehouseId = newWarehouseId;
            shelf.OccupiedSpace = totalOccupiedSpace;
            _context.Entry(shelf).State = EntityState.Modified;
            _context.SaveChanges();

            return shelf;
        }

        public ShelfEntity GetShelfById(int id)
        {
            return _context.Shelfs.FirstOrDefault(s => s.Id == id);
        }

        public bool DeleteShelf(int shelfId)
        {
            var productsInShelf = _context.SerialDocumnet
                .Where(sd => sd.ShelfId == shelfId)
                .ToList();

            if (productsInShelf.Count > 0)
            {
                throw new Exception("Please move your products to another shelf first.");
            }

            var shelf = _context.Shelfs.Find(shelfId);
            if (shelf != null)
            {
                var warehouse = _context.Warehouses.FirstOrDefault(w => w.Id == shelf.WarehouseId);
                if (warehouse != null)
                {
                    warehouse.EmptySpace += shelf.OccupiedSpace;
                    _context.Shelfs.Remove(shelf);
                    _context.SaveChanges();
                    return true;
                }
            }
            throw new Exception("Shelf not found.");
        }

        public List<ShelfEntity> GetShelvesByWarehouse(int warehouseId)
        {
            return _context.Shelfs.Where(s => s.WarehouseId == warehouseId).ToList();
        }

        public List<ShelfEntity> GetAllShelves()
        {
            return _context.Shelfs.ToList();
        }
    }
}
