using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.WarehouseDtos
{
    public class UpdateWarehouseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public int CityId { get; set; }
    }
}
