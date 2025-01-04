using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.DocumnetDtos
{
    public class Plan2DocumnetDTO
    {
        /// <summary>
        /// این DTO 
        /// برای ثبت تراکنش‌ها مانند ورود یا خروج کالا از انبار استفاده می‌شود. 
        /// این شامل اطلاعاتی از نوع تراکنش، شماره سریال محصولات و تاریخ می‌باشد.
        /// </summary> 
        public int Id { get; set; }
        public DateTime _DocumnetDate { get; set; }
        public int _SerialNumber { get; set; } // شماره سریال محصول
        public int _fromShelfId { get; set; }  //  شناسه قفسه مبدا 
        public int _toShelfId { get; set; } //  شناسه قفسه مقصد 
    
    }
}
