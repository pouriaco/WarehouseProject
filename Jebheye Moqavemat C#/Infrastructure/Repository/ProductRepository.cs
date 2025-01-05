using Domain.Entities;
using Domain.Interfaces.IProducts;
using Infrastructure.dbContext;
using Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private dbContextDatabase _db;

        public ProductRepository(dbContextDatabase db)
        {
            _db = db;
        }

        public ProductEntity CreateProduct(string name, int dimensions)
        {
            ProductEntity product = new ProductEntity()
            {
                Name = name,
                Dimensions = dimensions
            };
            _db.Products.Add(product);
            _db.SaveChanges();
            return product;
        }

        public ProductEntity GetProductById(int productId)
        {
            ProductEntity product = new ProductEntity();
            product = _db.Products.FirstOrDefault(x => x.Id == productId)!;
            if (product == null)
            {
                throw new("Product not found");
            }
            else
            {
                return product;
            }

        }

        public ProductEntity UpdateProduct(ProductEntity input)
        {
            ProductEntity product = _db.Products.FirstOrDefault(x => x.Id == input.Id)!;
            if (product == null)
            {
                throw new("Product not found");
            }
            else
            {

                product.Id = input.Id;
                product.Name = input.Name;
                product.Dimensions = input.Dimensions;

                _db.Products.Update(product);
                _db.SaveChanges();

            }

            return product!;
        }

        public bool DeleteProduct(int productId)
        {
            bool result = false;
            ProductEntity product = _db.Products.FirstOrDefault(y => y.Id == productId)!;
            if (product == null)
            {
                throw new("Product not found");
            }
            else
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
                result = true;
            }
            return result;

        }

        public List<ProductEntity> GetAllProducts()
        {
            return _db.Products.ToList();
        }
        public int GetProductSerialCount(int productId, int warehouseId)
        {
            int counter = 0;

            List<SerialEntity> serials = new List<SerialEntity>();
            serials = _db.Serials.Where(x => x.ProductId == productId).ToList();
            List<SerialDocumnetEntity> allSdList = new List<SerialDocumnetEntity>();
            allSdList = _db.SerialDocumnet.ToList();

            List<ShelfEntity> shleves = new List<ShelfEntity>();
            shleves = _db.Shelfs.Where(x => x.WarehouseId == warehouseId).ToList();

            List<SerialDocumnetEntity> serialSdList = new List<SerialDocumnetEntity>();
            List<SerialDocumnetEntity> shelfSerialSdList = new List<SerialDocumnetEntity>();
            List<DocumnetEntity> allDocument = _db.documnets.ToList();

            int inReport = 0;
            int outReport = 0;
            foreach (var item in serials)
            {
                foreach (var doc in allSdList)
                {
                    if (item.Id == doc.SerialId)
                    {
                        serialSdList.Add(doc);
                    }
                }
            }
            foreach (var item in shleves)
            {
                foreach (var SSDL in serialSdList)
                {
                    if (item.Id == SSDL.ShelfId)
                    {
                        shelfSerialSdList.Add(SSDL);
                    }
                }
            }
            foreach (var item in shelfSerialSdList)
            {
                foreach (var doc in allDocument)
                {
                    if (item.DocumnetId == doc.Id)
                    {
                        if (doc.EntryExit == 0)
                        {
                            inReport++;
                        }
                        else
                        {
                            outReport++;
                        }
                    }
                }
            }
            return inReport - outReport;
         
            //// ????? ???? ????????? ????? ??? ?? ????? ???????
            //var serials = _db.Serials
            //    .Where(x => x.ProductId == productId)
            //    .ToList();

            //// ???? ?????? ????? ?? ??? ????????
            //var serialDocumnets = _db.SerialDocumnet
            //    .Where(sd => serials.Any(s => s.Id == sd.SerialId))  // ??? ?????? ?? ????? ?? ????????? ???? ??? ?????
            //    .ToList();

            //// ???? ???????? ????? ?? ?????
            //var shelves = _db.Shelfs
            //    .Where(shelf => shelf.WarehouseId == warehouseId)
            //    .ToList();

            //// ???? ?????? ????? ?? ???????? ?????
            //var shelfSerialDocumnets = serialDocumnets
            //    .Where(sd => shelves.Any(shelf => shelf.Id == sd.ShelfId))  // ??? ??????? ?? ????? ?? ???????? ????? ?????
            //    .ToList();

            //// ?????? ????? ?? ???? ? ????
            //var documents = _db.documnets
            //    .Where(doc => shelfSerialDocumnets.Any(sd => sd.DocumnetId == doc.Id))
            //    .ToList();

            //// ????? ???? ? ????
            //var inReport = documents
            //    .Count(doc => doc.EntryExit == 0);  // ???? ????

            //var outReport = documents
            //    .Count(doc => doc.EntryExit == 1);  // ???? ????

            //// ?????? ????? ??????? ????? (????? ???? - ????? ????)
            //return inReport - outReport;
        

        }

        public IEnumerable<dynamic> GetProductLocationDetails(int productId)
        {
            //    var query = _db.SerialDocumnet
            //        .Where(sd => sd.Serial.ProductId == productId)  
            //        .Where(sd => sd.Documnet.EntryExit == DocumnetEntity.DocumnetType.vorud) 
            //        .Join(_db.Shelfs,
            //              sd => sd.ShelfId,
            //              shelf => shelf.Id,
            //              (sd, shelf) => new { sd, shelf })  
            //        .Join(_db.Warehouses,
            //              combined => combined.shelf.WarehouseId,
            //              warehouse => warehouse.Id,
            //              (combined, warehouse) => new { combined.sd, combined.shelf, warehouse }) 
            //        .GroupBy(data => new
            //        {
            //            data.warehouse.Id,         
            //            data.warehouse.Name         
            //        })
            //        .Select(group => new
            //        {
            //            WarehouseId = group.Key.Id,    
            //            WarehouseName = group.Key.Name, 
            //            ProductCount = group.Count()    
            //        })
            //        .ToList();

            //    if (!query.Any()) 
            //    {
            //        throw new Exception("No data found for this product in any warehouse.");
            //    }

            //    return query; 
            //}
            List<WarehouseEntity> warehouses = _db.Warehouses.ToList();
            List<string> productLocationDetails = new List<string>();
            ProductEntity product = _db.Products.FirstOrDefault(x => x.Id == productId)!;
            int productCount = 0;
            foreach (var item in warehouses)
            {
                productCount = GetProductSerialCount(productId, item.Id);
                productLocationDetails.Add(" There is " + productCount + " of " + product.Name + " in " + item.Name);
            }
            return productLocationDetails;
             }
        }
}
