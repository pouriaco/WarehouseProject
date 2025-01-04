using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.WarehouseDtos
{
    internal class CRUDShelfDTO
    {
        public int _WarehouseId { get; set; }
        public int _OccupiedSpace { get; set; } // فضای اشغال شده
        public int _Levels { get; set; } // طبقه
    }
}
