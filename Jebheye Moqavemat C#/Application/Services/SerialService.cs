using Domain.Entities;
using Domain.Interfaces.IProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SerialService 
    {
        private ISerialRepository _serialRepository;
        public SerialService(ISerialRepository serialRepository)
        {
            _serialRepository = serialRepository;
        }
        public SerialEntity CreateSerial(int productId)
        {
            return _serialRepository.CreateSerial(productId);
        }
        public SerialEntity GetSerialById(int serialId)
        {
            return _serialRepository.GetSerialById(serialId);
        }
        public bool DeleteSerial(int serialId)
        {
            return _serialRepository.DeleteSerial(serialId);
        }
        public IEnumerable<SerialEntity> GetAllSerials()
        {
            return _serialRepository.GetAllSerials();
        }

    }
}
