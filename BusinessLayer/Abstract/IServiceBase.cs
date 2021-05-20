using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IServiceBase<T> where T:class,IEntity,new()
    {
        List<T> GetList();
        void Add(T entity);
        T GetById(int id);
        void Delete(T entity);
        void Update(T entity);
    }
}
