using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService:IServiceBase<Heading>
    {
        List<HeadingDetailDto> GetHeadingDetails();
        List<Heading> GetListByWriter(int id);
    }
}
