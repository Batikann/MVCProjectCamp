using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class HeadingDetailDto:IDto
    {
        public int HeadingID { get; set; }
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }
        public string CategoryName { get; set; }
        public string WriterName { get; set; }
        public string WriterSurname { get; set; }
    }
}
