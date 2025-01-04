using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.WarehouseDtos
{
    public class CRUDShelfDTO
    {
        public int WarehouseId { get; set; }
        public int OccupiedSpace { get; set; } // فضای اشغال شده
        public int Levels { get; set; } // طبقه
    }
}
