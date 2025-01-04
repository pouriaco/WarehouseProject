using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SerialDocumnetEntity
    {
        public int Id { get; set; }
        public SerialEntity Serial { get; set; }
        public int SerialId { get; set; }
        public DocumnetEntity Documnet { get; set; }
        public int DocumnetId { get; set; }
        public ShelfEntity Shelf { get; set; }
        public int ShelfId { get; set; }
    }
}
