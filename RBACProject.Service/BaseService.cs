using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RBACProject.IRepository;
using RBACProject.IService;

namespace RBACProject.Service
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        public IBaseRepository<T> baseRepository { get; set; }

        public bool Delete(T model)
        {
           return baseRepository.Delete(model);
        }

        public bool Delete(List<T> models)
        {
            return baseRepository.Delete(models);
        }

        public bool DeleteByWhere(Expression<Func<T, bool>> where)
        {
            return baseRepository.DeleteByWhere(where);
        }

        public bool Insert(T model)
        {
            return baseRepository.Insert(model);
        }

        public bool Insert(List<T> models)
        {
            return baseRepository.Insert(models);
        }

        public List<T> queryAll()
        {
            return baseRepository.queryAll();
        }

        public List<T> queryByWhere(Expression<Func<T, bool>> expression)
        {
            return baseRepository.queryByWhere(expression);
        }

        public T QuerySingle(Expression<Func<T, bool>> expression)
        {
            return baseRepository.QuerySingle(expression);
        }

        public bool Update(T model)
        {
            return baseRepository.Update(model);
        }

        public bool Update(List<T> models)
        {
            return baseRepository.Update(models);
        }

        public bool Update(Expression<Func<T, bool>> expression)
        {
            return baseRepository.Update(expression);
        }

        public bool Update(Expression<Func<List<T>, bool>> expression)
        {
            return baseRepository.Update(expression);
        }
    }
}
