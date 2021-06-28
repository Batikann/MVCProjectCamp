using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class WriterLoginDto:IDto
    {
        public string WriterName { get; set; }
        public string WriterSurName { get; set; }
        public string WriterUserName { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
    }
}
