using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T> where T:class,IEntity,new()
    {
        void Insert(T t);
        T Get(Expression<Func<T, bool>> filter);
        void Delete(T t);
        void Update(T t);
        List<T> List(Expression<Func<T, bool>> filter=null);
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> filter);


    }
}
