using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IDocumnets
{
    internal interface IDocumnetRepository
    {
    /* C */  public SerialDocumnetEntity RecordDocumnet(int serialNumber, int shelfId, Enum type, DateTime documnetDate);
    /* R */  public DocumnetEntity ReverseDocumnet(int documnetId); 
    /* D */  public bool DeletDocumnet(int documnetId);
             public  IEnumerable<DocumnetEntity> GetDocumnetHistory(int warehouseId); // دریافت تاریخچه تراکنش‌های یک انبار بر اساس شناسه

    }
}
