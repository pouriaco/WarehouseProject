using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.DocumnetDtos
{
    public class Plan1DocumnetDTO
    {
        /// <summary>
        /// این DTO 
        /// برای ثبت تراکنش‌ها مانند ورود به انبار استفاده می‌شود. 
        /// این شامل اطلاعاتی از نوع تراکنش، شماره سریال محصولات و تاریخ می‌باشد.
        /// </summary> 
        public int Id { get; set; }
        public DateTime _DocumnetDate { get; set; }
        public int _ProductId { get; set; } 
        public int _toShelfId { get; set; } //  شناسه قفسه مقصد 
    }
}
