using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ProductDtos
{
    internal class ProductManagementDTO
    {
        /// <summary>
        /// ین DTO
        /// برای مدیریت کالاهای موجود در انبار استفاده می‌شود. 
        /// اطلاعات محصول، ابعاد، و وضعیت موجودی کالا در انبار در این دی تی او قرار دارد.
        /// </summary>
        public int _SerialNumber { get; set; }  // شماره سریال محصول
        public string _ProductName { get; set; }  // نام محصول
        public double _Dimensions { get; set; } // ابعاد محصول
        public int _WarehouseId { get; set; } // شناسه انبار
        public int _ShelfId { get; set; } // شناسه قفسه
        //public int _Quantity { get; set; }  // تعداد موجود از محصول
    }
}
