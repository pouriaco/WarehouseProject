using Domain.Entities;
using Domain.Interfaces.IProducts;
using Infrastructure.dbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class SerialRepository : ISerialRepository
    {
        private dbContextDatabase _db;
        public SerialRepository(dbContextDatabase db)
        {
            _db = db;
        }

        public SerialEntity CreateSerial(int productId)
        {

            var NewSerial = new SerialEntity()
            {
                ProductId = productId,
            };
            _db.Serials.Add(NewSerial);
            _db.SaveChanges();
            return NewSerial;
        }
        public SerialEntity GetSerialById(int serialId)
        {
           SerialEntity Serial = _db.Serials.FirstOrDefault(s => s.Id == serialId)!;
            if (Serial == null) 
            {
                throw new("Serial not found");
            }
            return Serial;
        }

        public bool DeleteSerial(int serialId)
        {
            var serial = _db.Serials.FirstOrDefault(s => s.Id == serialId);
            if (serial != null)
            {
                _db.Serials.Remove(serial);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<SerialEntity> GetAllSerials()
        {
            return _db.Serials.ToList();
        }

      
    }
}
