using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.WarehouseDtos
{
    internal class WarehouseCapacityCheckDTO
    {
        /// <summary>
        /// این DTO
        /// برای بررسی ظرفیت فعلی انبار و ارزیابی میزان فضای موجود استفاده می‌شود.
        /// </summary>
        public int _WarehouseId { get; set; } // شناسه انبار
        public double _Area { get; set; } // مساحت انبار
        public double _CurrentCapacity { get; set; } // ظرفیت فعلی انبار
        public double _RemainingCapacity { get; set; } // ظرفیت باقی‌مانده انبار
    }
}
