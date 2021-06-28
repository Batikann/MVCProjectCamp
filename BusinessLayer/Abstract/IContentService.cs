using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService:IServiceBase<Content>
    {
        List<Content> GetListByHeadingId(int id);
        List<Content> GetListByWriter(int id);
    }
}
