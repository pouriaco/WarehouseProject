using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ShelfEntity
    {
        public int Id { get; set; }
        public WarehouseEntity Warehouse { get; set; }
        public int WarehouseId { get; set; }
        public int? OccupiedSpace { get; set; }
        public int? Levels { get; set; }
    }
}
