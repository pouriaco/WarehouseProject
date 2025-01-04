using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DocumnetEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DocumnetType EntryExit { get; set; }
        public enum  DocumnetType
        {
            vorud ,
            khroj
        }
    }
}
