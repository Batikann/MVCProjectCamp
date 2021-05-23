using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContentDal : GenericRepository<Content, Context>, IContentDal
    {
      
        public List<ContentDetailDto> ContentDetails(Expression<Func<Content, bool>> filter)
        {
            using (Context context = new Context())
            {
                var result = from c in context.Contents
                             join h in context.Headings on c.HeadingID equals h.HeadingID
                             join w in context.Writers on c.WriterID equals w.WriterID
                             select new ContentDetailDto { HeadingID = h.HeadingID, ContentDate = c.ContentDate, ContentValue = c.ContentValue, HeadingName = h.HeadingName, WriterName = w.WriterName, WriterSurname = w.WriterSurName };

                return result.ToList();
            }
        }
    }
}
