using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IProducts
{
    public interface IProductRepository
    {
      /* C */  public ProductEntity CreateProduct(string name, int dimensions); 
      /* R */  public ProductEntity GetProductById(int productId);
      /* U */  public ProductEntity UpdateProduct(ProductEntity input);
      /* D */  public bool DeleteProduct(int productId);
               public List<ProductEntity> GetAllProducts();
               public int GetProductSerialCount(int productId, int warehouseId); // گزارش تعداد سریال‌های یک محصول خاص در یک انبار مشخص
    }
}
