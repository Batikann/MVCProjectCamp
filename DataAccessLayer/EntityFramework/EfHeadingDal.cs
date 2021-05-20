using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfHeadingDal : GenericRepository<Heading, Context>, IHeadingDal
    {
        public List<HeadingDetailDto> HeadingDetails()
        {
            using (Context context=new Context())
            {
                var result = from h in context.Headings
                             join c in context.Categories on h.CategoryID equals c.CategoryID
                             join w in context.Writers on h.WriterID equals w.WriterID
                             select new HeadingDetailDto
                             { HeadingID = h.HeadingID, CategoryName = c.CategoryName, HeadingDate = h.HeadingDate, HeadingName = h.HeadingName, WriterName = w.WriterName,WriterSurname=w.WriterSurName };

                return result.ToList();
            }
        }
    }
}
