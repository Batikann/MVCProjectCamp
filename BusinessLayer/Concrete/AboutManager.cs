using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About entity)
        {
            _aboutDal.Insert(entity);
        }

        public void Delete(About entity)
        {
            if (entity.AboutStatus==false)
            {
                entity.AboutStatus = true;
                _aboutDal.Update(entity);
            }
            else
            {
                entity.AboutStatus =false;
                _aboutDal.Update(entity);
            }
        }

        public About GetById(int id)
        {
           return  _aboutDal.Get(x => x.AboutID == id);
        }

        public List<About> GetList()
        {
            return _aboutDal.List();
        }

        public void Update(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
