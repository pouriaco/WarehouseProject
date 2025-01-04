using Domain.Entities;
using Domain.Interfaces.IDocumnets;
using Domain.Interfaces.IProducts;
using Infrastructure.dbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class DocumnetRepository : IDocumnetRepository
    {
        private dbContextDatabase _db;
        private SerialRepository _serialRepository;
        public DocumnetRepository(dbContextDatabase db)
        {
            _db = db;
            _serialRepository = new SerialRepository(_db);
        }
        public SerialDocumnetEntity RecordDocumentAndGenerateProducts(int productId, int toshelfId, DateTime documnetDate)
        {
            //Plan:1
            SerialEntity serial = new SerialEntity();
            ProductEntity product = _db.Products.FirstOrDefault(x => x.Id == productId)!;
            DocumnetEntity newDocumnet = new DocumnetEntity();
            SerialDocumnetEntity newSerialDoc = new SerialDocumnetEntity();
            if (product != null)
            {
                serial = _serialRepository.CreateSerial(productId);
            }
            if (serial != null)
            {
                newDocumnet = new DocumnetEntity()
                {
                    Date = documnetDate,
                    EntryExit = DocumnetEntity.DocumnetType.vorud
                };

                _db.documnets.Add(newDocumnet);
                _db.SaveChanges();

                newSerialDoc = new SerialDocumnetEntity()
                {
                    DocumnetId = newDocumnet.Id,
                    SerialId = serial.Id,
                    ShelfId = toshelfId
                };
                _db.SerialDocumnet.Add(newSerialDoc);
                _db.SaveChanges();
                ShelfEntity shelf = _db.Shelfs.FirstOrDefault(x => x.Id == toshelfId)!;
                if (shelf != null && shelf.OccupiedSpace - product.Dimensions > 0)
                {
                    shelf.OccupiedSpace -= product.Dimensions;
                    _db.SaveChanges();
                }
            }
            return newSerialDoc;
        }

        //Plan:2
        public SerialDocumnetEntity RecordDocumnet(int serialNumber, int fromshelfId, int toshelfId, DateTime documnetDate)
        {
            //PLAN:2
            var serial = _db.Serials.FirstOrDefault(x => x.Id == serialNumber);
            var product = _db.Products.FirstOrDefault(x => x.Id == serial.ProductId);
            if (product == null)
            {
                throw new Exception("Product not found.");
            }
            var NewDocumnet = new DocumnetEntity()
            {
                Date = documnetDate,
                EntryExit = DocumnetEntity.DocumnetType.khroj
            };
            if (fromshelfId != 0)
            {
                _db.documnets.Add(NewDocumnet);
                _db.SaveChanges();
            }

            var SerialDocumnet = new SerialDocumnetEntity()
            {
                SerialId = serialNumber,
                ShelfId = fromshelfId,
                DocumnetId = NewDocumnet.Id,
            };
            if (fromshelfId != 0)
            {
                _db.SerialDocumnet.Add(SerialDocumnet);
                _db.SaveChanges();
            }

            var productDimensions = product.Dimensions;
            var fromshelf = _db.Shelfs.FirstOrDefault(x => x.Id == fromshelfId);
            if (fromshelf != null)
            {
                fromshelf.OccupiedSpace += productDimensions;
                _db.SaveChanges();
            }
            //////////////////////////////////////
            var newDocumnet = new DocumnetEntity()
            {
                Date = documnetDate,
                EntryExit = DocumnetEntity.DocumnetType.vorud
            };
            _db.documnets.Add(newDocumnet);
            _db.SaveChanges();

            var serialDocumnet = new SerialDocumnetEntity
            {
                SerialId = serialNumber,
                ShelfId = toshelfId,
                DocumnetId = newDocumnet.Id
            };
            _db.SerialDocumnet.Add(serialDocumnet);
            _db.SaveChanges();

            var toShelf = _db.Shelfs.FirstOrDefault(s => s.Id == toshelfId);
            if (toShelf != null)
            {
                toShelf.OccupiedSpace -= productDimensions;
                _db.SaveChanges();
            }
            return serialDocumnet;
        }

        public DocumnetEntity ReverseDocumnet(int documnetId)
        {
            DocumnetEntity documnet = new DocumnetEntity();
            documnet = _db.documnets.FirstOrDefault(x => x.Id == documnetId)!;
            if (documnet == null)
            {
                throw new("Documnet not found");
            }
            else
            {
                return documnet;
            }
        }

        public bool DeletDocumnet(int documnetId)
        {
            bool result = false;
            DocumnetEntity documnet = _db.documnets.FirstOrDefault(y => y.Id == documnetId)!;
            if (documnet == null)
            {
                throw new("Documnet not found");
            }
            else
            {
                _db.documnets.Remove(documnet);
                _db.SaveChanges();
                result = true;
            }
            return result;
        }

        public IEnumerable<DocumnetEntity> GetDocumnetHistory(int warehouseId)
        {

            var shelves = _db.Shelfs.Where(s => s.WarehouseId == warehouseId).ToList();
      
            var documentIds = _db.SerialDocumnet
                .Where(sd => shelves.Select(s => s.Id).Contains(sd.ShelfId)) 
                .Select(sd => sd.DocumnetId) 
                .Distinct()
                .ToList();
            if (!documentIds.Any())
            {
                throw new("No document found in this warehouse");
            }
            var documentHistory = _db.documnets
                .Where(d => documentIds.Contains(d.Id))
                .OrderBy(d => d.Date)
                .ToList();

            return documentHistory;
        }

     
    }
}
