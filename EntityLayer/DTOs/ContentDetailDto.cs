using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class ContentDetailDto:IDto
    {
        public int HeadingID { get; set; }
        public string HeadingName { get; set; }
        public string WriterName { get; set; }
        public string WriterSurname { get; set; }
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }
    }
}
