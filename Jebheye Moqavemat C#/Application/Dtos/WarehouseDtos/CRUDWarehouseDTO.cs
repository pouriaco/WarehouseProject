using System;
using System.Collections.Generic;

namespace Application.Dtos.WarehouseDtos
{
    public class CRUDWarehouseDTO
    {
        public string Name { get; set; } // نام انبار
        public double Area { get; set; } // مساحت انبار
        public int CityId { get; set; } // شناسه شهر
    }
}