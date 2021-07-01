using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Add(Content entity)
        {
            _contentDal.Insert(entity);
        }

        public void Delete(Content entity)
        {
            throw new NotImplementedException();
        }

        public Content GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList()
        {
            return _contentDal.GetAll();
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _contentDal.GetAll(c => c.HeadingID == id);

        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.GetAll(x => x.WriterID == id);
        }

        public List<Content> SearchText(string p)
        {
            return _contentDal.GetAll(x=>x.ContentValue.Contains(p));
        }

        public void Update(Content entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
