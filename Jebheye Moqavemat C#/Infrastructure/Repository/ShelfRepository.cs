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

        public ShelfEntity CreateShelf(int occupiedSpace, int levels, int warehouseId)
        {
            try
            {
                // مرحله 1: اعتبارسنجی انبار
                var warehouse = _context.Warehouses.FirstOrDefault(w => w.Id == warehouseId);
                if (warehouse == null)
                {
                    throw new Exception("Warehouse not found");
                }

                // مرحله 2: بررسی فضای انبار
                var totalOccupiedSpace = _context.Shelfs
                    .Where(s => s.WarehouseId == warehouseId)
                    .Sum(s => s.OccupiedSpace);
                var availableSpace = warehouse.Area - totalOccupiedSpace;

                if (occupiedSpace > availableSpace)
                {
                    throw new Exception("Not enough space in the warehouse");
                }

                // مرحله 3: ایجاد قفسه
                var shelf = new ShelfEntity
                {
                    OccupiedSpace = occupiedSpace,
                    Levels = levels,
                    WarehouseId = warehouseId
                };
                _context.Shelfs.Add(shelf);
                _context.SaveChanges();
                return shelf;
            }
            catch (Exception ex)
            {
                throw new Exception("Creation failed due to an error: " + ex.Message);
            }
        }

        public ShelfEntity UpdateShelf(int shelfId, int newWarehouseId)
        {
            // مرحله 1: اعتبارسنجی انبار جدید
            var newWarehouse = _context.Warehouses.FirstOrDefault(w => w.Id == newWarehouseId);
            if (newWarehouse == null)
            {
                throw new Exception("New warehouse not found");
            }

            // مرحله 2: بررسی فضای انبار جدید
            var totalOccupiedSpace = _context.Shelfs
                .Where(s => s.WarehouseId == newWarehouseId)
                .Sum(s => s.OccupiedSpace);
            var availableSpace = newWarehouse.Area - totalOccupiedSpace;

            var shelf = _context.Shelfs.FirstOrDefault(s => s.Id == shelfId);
            if (shelf == null)
            {
                throw new Exception("Shelf not found");
            }

            if (shelf.OccupiedSpace > availableSpace)
            {
                throw new Exception("Not enough space in the new warehouse");
            }

            // مرحله 3: بروزرسانی قفسه
            shelf.WarehouseId = newWarehouseId;
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
            try
            {
                // مرحله 1: بررسی موجودیت محصولات در قفسه
                var productsInShelf = _context.SerialDocumnet
                                              .Where(sd => sd.ShelfId == shelfId)
                                              .ToList();

                if (productsInShelf.Count > 0)
                {
                    throw new Exception("Please move your products to another shelf first.");
                }

                // مرحله 2: حذف قفسه
                var shelf = _context.Shelfs.Find(shelfId);
                if (shelf != null)
                {
                    _context.Shelfs.Remove(shelf);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("Shelf not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Deletion failed: " + ex.Message);
            }
        }

        public List<ShelfEntity> GetShelvesByWarehouse(int warehouseId)
        {
            return _context.Shelfs.Where(s => s.WarehouseId == warehouseId).ToList();
        }
    }
}
