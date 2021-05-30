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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Add(Contact entity)
        {
            _contactDal.Insert(entity);
        }

        public void Delete(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public Contact GetById(int id)
        {
           return _contactDal.Get(x => x.ContactID == id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }

        public void Update(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
