using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IContentDal:IRepository<Content>
    {
        List<ContentDetailDto> ContentDetails(Expression<Func<Content, bool>> filter);
    }
}
