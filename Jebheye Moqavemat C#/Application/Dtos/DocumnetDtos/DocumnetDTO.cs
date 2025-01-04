using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.DocumnetDtos
{
    internal class DocumnetDTO
    {
        /// <summary>
        /// این DTO 
        /// برای ثبت تراکنش‌ها مانند ورود یا خروج کالا از انبار استفاده می‌شود. 
        /// این شامل اطلاعاتی از نوع تراکنش، شماره سریال محصولات، تعداد، و تاریخ می‌باشد.
        /// </summary>
        ///   
        /// //public int _Quantity { get; set; } // تعداد محصول در تراکنش
        public int Id { get; set; }
        public DateTime _DocumnetDate { get; set; }
        public int _SerialProduct { get; set; } // شماره سریال محصول
        public int _ShelfId { get; set; }  // شناسه قفسه
        public DocumnetType _Type { get; set; } // نوع تراکنش (ورود یا خروج)
        public enum DocumnetType
        {
        Entry = 1 , 
        Exit = 2 ,
        }
    }
}
