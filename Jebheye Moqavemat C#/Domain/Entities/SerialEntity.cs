using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SerialEntity
    {
        public int Id { get; set; }
        public ProductEntity Product { get; set; }
        public int ProductId { get; set; }
        List<SerialDocumnetEntity> SerialDocumnet { get; set; }
    }
}
