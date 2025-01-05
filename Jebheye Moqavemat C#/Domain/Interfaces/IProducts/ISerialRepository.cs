using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IProducts
{
    public interface ISerialRepository
    {
    /* C */  public  SerialEntity CreateSerial(int productId);    
    /* R */  public  SerialEntity GetSerialById(int serialId);
    /* R */  public  string GetSerialLocationById(int serialId);
    /* D */  public bool DeleteSerial(int serialId);
             public IEnumerable<SerialEntity> GetAllSerials();
    }
}
