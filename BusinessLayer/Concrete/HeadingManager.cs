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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void Add(Heading entity)
        {
            _headingDal.Insert(entity);
        }

        public void Delete(Heading entity)
        {
            if (entity.HeadingStatus == false)
            {
                entity.HeadingStatus = true;
                _headingDal.Update(entity);
            }
            else
            {
                entity.HeadingStatus = false;
                _headingDal.Update(entity);
            }
            

        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<HeadingDetailDto> GetHeadingDetails()
        {
            return _headingDal.HeadingDetails();
        }

        public List<Heading> GetList()
        {
            return _headingDal.GetAll();
        }

        public void Update(Heading entity)
        {
            _headingDal.Update(entity);
        }
    }
}
