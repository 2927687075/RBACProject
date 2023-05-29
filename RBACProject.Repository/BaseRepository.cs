using System;   
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SqlsugarHelper;

namespace RBACProject.IRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        SqlSugarHelper sqlSugarHelper =  new SqlSugarHelper();
        
        #region delete
        public bool Delete(int Id)
        {
            return SqlSugarHelper.db.Deleteable<T>().ExecuteCommand() > 0;
        }

        public bool Delete(T model)
        {
            return SqlSugarHelper.db.Deleteable<T>(model).ExecuteCommand() > 0;
        }

        public bool Delete(List<T> models)
        {
            return SqlSugarHelper.db.Deleteable<List<T>>(models).ExecuteCommand() > 0;
        }

        public bool DeleteByWhere(Expression<Func<T, bool>> where)
        {
            return SqlSugarHelper.db.Deleteable<T>().Where(where).ExecuteCommand() > 0;
        }

        #endregion delete

        #region insert
        public bool Insert(T model)
        {
            return SqlSugarHelper.db.Insertable<T>(model).ExecuteCommand() > 0;
        }

        public bool Insert(List<T> models)
        {
            return SqlSugarHelper.db.Insertable<List<T>>(models).ExecuteCommand() > 0;
        }
        #endregion

        #region query
        public T QuerySingle(Expression<Func<T, bool>> where)
        {
            return SqlSugarHelper.db.Queryable<T>().First(where);
        }
        public List<T> queryAll()
        {
            return SqlSugarHelper.db.Queryable<T>().ToList();
        }

        public List<T> queryByWhere(Expression<Func<T, bool>> expression)
        {
            return SqlSugarHelper.db.Queryable<T>().Where(expression).ToList();
        }
        #endregion

        #region update
        public bool Update(T model)
        {
            return SqlSugarHelper.db.Updateable<T>(model).ExecuteCommand() > 0;
        }

        public bool Update(List<T> models)
        {
            return SqlSugarHelper.db.Updateable<List<T>>(models).ExecuteCommand() > 0;
        }

        public bool Update(Expression<Func<T, bool>> expression)
        {
            return SqlSugarHelper.db.Updateable<T>(expression).ExecuteCommand() > 0;
        }

        public bool Update(Expression<Func<List<T>, bool>> expression)
        {
            return SqlSugarHelper.db.Updateable<List<T>>(expression).ExecuteCommand() > 0;
        }


        #endregion

    }
}
