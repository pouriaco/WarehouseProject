using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class WarehouseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CityEntity City { get; set; }
        public int CityId { get; set; }
        public double Area { get; set; }
        public double EmptySpace {  get; set; }
        List<ShelfEntity> Shelf { get; set; }
    }
}
