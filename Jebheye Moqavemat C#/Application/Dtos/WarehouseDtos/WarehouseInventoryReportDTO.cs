using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.WarehouseDtos
{
    internal class WarehouseInventoryReportDTO
    {
        /// <summary>
        /// این DTO
        /// برای گزارش وضعیت موجودی انبار و کالاها به کار می‌رود. 
        /// در این گزارش، تعداد و جزئیات کالاهای موجود در انبار نمایش داده می‌شود.
        /// </summary>
        public int _WarehouseId { get; set; } 
        public string _WarehouseName { get; set; }
        public List<ProductInventoryDTO> _Products { get; set; }

        public class ProductInventoryDTO
        {
            public int _SerialNumber { get; set; } 
            public string _ProductName { get; set; } 
            public int _Quantity { get; set; } // تعداد
        }
    }
}
