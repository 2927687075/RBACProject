using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlsugarHelper;

namespace RBACProject.IRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        #region delete
        public bool Delete(int Id)
        {
            return SqlSugarHelper<T>.Delete(Id);
        }

        public bool Delete(T model)
        {
            return SqlSugarHelper<T>.Delete(model);
        }

        public bool Delete(List<T> models)
        {
            return SqlSugarHelper<T>.Delete(models);
        }

        public bool DeleteByWhere(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return SqlSugarHelper<T>.Delete(where);
        }

        #endregion delete

        #region insert
        public bool Insert(T model)
        {
           return SqlSugarHelper<T>.Insert(model);
        }

        public bool Insert(List<T> models)
        {
            return SqlSugarHelper<T>.Insert(models);
        }
        #endregion

        #region query
        public List<T> queryAll()
        {
            throw new NotImplementedException();
        }

        public List<T> queryByWhere(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public T querySingle(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region update
        public bool Update(T model)
        {
            return SqlSugarHelper<T>.Update(model);
        } 
        #endregion


 
    }
}
