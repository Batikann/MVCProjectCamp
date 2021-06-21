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
    public class TalentManager : ITalentService
    {
        ITalentDal _talentDal;

        public TalentManager(ITalentDal talentDal)
        {
            _talentDal = talentDal;
        }

        public void Add(Talent entity)
        {
            _talentDal.Insert(entity);
        }

        public void Delete(Talent entity)
        {
            _talentDal.Delete(entity);
        }

        public Talent GetById(int id)
        {
            return _talentDal.GetById(x => x.TalentID == id);
        }

        public List<Talent> GetList()
        {
            return _talentDal.List();
        }

        public void Update(Talent entity)
        {
            _talentDal.Update(entity);
        }
    }
}
