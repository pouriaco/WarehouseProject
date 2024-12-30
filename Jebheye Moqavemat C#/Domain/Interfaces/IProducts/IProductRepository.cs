using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IProducts
{
    internal interface IProductRepository
    {
      /* C */  public ProductEntity CreateProduct(string name, int dimensions); 
      /* R */  public int GetProductById(int productId);
      /* U */  public ProductEntity UpdateProduct(string name , int dimensions);
      /* D */  public int DeleteProduct(int productId);
               public int GetProductSerialCount(int productId, int warehouseId); // گزارش تعداد سریال‌های یک محصول خاص در یک انبار مشخص
    }
}
